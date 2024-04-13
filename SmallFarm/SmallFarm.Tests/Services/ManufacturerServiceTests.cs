using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Core.Models.Request;
using SmallFarm.Core.Services;
using SmallFarm.Data;
using SmallFarm.Data.Entities;
using SmallFarm.Tests.Mocks;

namespace SmallFarm.Tests.Services
{
    [TestFixture]
    public class ManufacturerServiceTests
    {
        private SmallFarmDbContext context;
        private IMapper mapper;
        private IManufacturerService manufacturerService;

        private Manufacturer? manufacturer;

        [SetUp]
        public async Task SetUp()
        {
            this.context = DatabaseMock.Instance;
            this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<SmallFarmProfile>()));

            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == "example@gmail.com");
            
            var userManager = UserManagerMock.Instance;
            userManager
                .Setup(x => x.FindByEmailAsync("example@gmail.com"))
                .ReturnsAsync(new ApplicationUser());

            userManager.Setup(x => x.AddToRoleAsync(user, "Manufacturer")).ReturnsAsync(IdentityResult.Success);
            userManager.Setup(x => x.RemoveFromRoleAsync(user, "Manufacturer")).ReturnsAsync(IdentityResult.Success);

            this.manufacturerService = new ManufacturerService(context, mapper, userManager.Object);
            this.manufacturer = await context.Manufacturers.FirstOrDefaultAsync(m => m.Email == "manu@gmail.com");

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task GetManufacturerByIdAsync_ShouldReturnManufacturer()
        {
            var manu = await manufacturerService.GetManufacturerByIdAsync(this.manufacturer.Id);

            Assert.AreEqual(this.manufacturer.Id, manu.Id);
        }

        [Test]
        public async Task AddManufacturerAsync_ShouldAddManufacturer()
        {
            var request = new RequestFormModel()
            {
                Id = Guid.NewGuid(),
                ManufacturerName = "Manufacturer",
                ManufacturerDescription = "Our company is the best on the market!",
                ManufacturerPhoneNumber = "+359888888888",
                CityId = 1,
                ManufacturerAddress = "ul. Bulgaria",
                UserEmail = "example@gmail.com"
            };

            await manufacturerService.AddManufacturerAsync(request);

            var allManufacturers = await manufacturerService.GetAllManufacturersAsync();

            Assert.IsTrue(allManufacturers.Any(m => m.Email == "example@gmail.com"));
        }

        [Test]
        public async Task DeleteManufacturerAsync_ShouldRemoveManufacturerAndItsRole()
        {
            await manufacturerService.DeleteManufacturerAsync(manufacturer.Id);

            var user = await context.Users.FirstAsync(u => u.Email == "manu@gmail.com");
            var roleIsDeleted =
                await context.UserRoles.FirstOrDefaultAsync(r => r.UserId == user.Id) == null;

            Assert.AreEqual(false, context.Manufacturers.Any(u => u.Email == "manu@gmail.com"));
            Assert.AreEqual(true, roleIsDeleted);
        }

        [Test]
        public async Task EditManufacturerAsync_ShouldEditManufacturer()
        {
            this.manufacturer = new Manufacturer()
            {
                Id = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                Name = "BestProducts OOD",
                Address = "bul. Todor Kableshkov",
                CityId = 1,
                Description = "We are one of the best on the market!",
                Email = "manu@gmail.com",
                PhoneNumber = "+359885118198"
            };

            var expected = manufacturer.Name + "Test";
            await manufacturerService.EditManufacturerAsync(manufacturer.Id, new ManufacturerFormModel
            {
                Name = expected,
                Description = manufacturer.Description,
                PhoneNumber = manufacturer.PhoneNumber,
                Address = manufacturer.Address,
                CityId = manufacturer.CityId,
                Email = manufacturer.Email
            });

            var editedManufacturer = await manufacturerService.GetManufacturerByIdAsync(manufacturer.Id);
            Assert.AreEqual(expected, editedManufacturer.Name);
        }
    }
}
