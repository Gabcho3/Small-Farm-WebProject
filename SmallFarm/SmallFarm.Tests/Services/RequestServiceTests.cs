using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models.Request;
using SmallFarm.Core.Services;
using SmallFarm.Data;
using SmallFarm.Data.Entities;
using SmallFarm.Tests.Mocks;

namespace SmallFarm.Tests.Services
{
    [TestFixture]
    public class RequestServiceTests
    {
        private SmallFarmDbContext context;
        private IMapper mapper;
        private IRequestService requestService;

        [SetUp]
        public async Task SetUp()
        {
            this.context = DatabaseMock.Instance;
            this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<SmallFarmProfile>()));

            var userManager = UserManagerMock.Instance;
            userManager
                .Setup(x => x.FindByEmailAsync("example@gmail.com"))
                .ReturnsAsync(new ApplicationUser());

            var manufacturerService = new Mock<IManufacturerService>();
            manufacturerService.Setup(m => m.AddManufacturerAsync(new RequestFormModel())).Returns(Task.CompletedTask);

            this.requestService = new RequestService(context, mapper, userManager.Object, manufacturerService.Object);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task AddAsync_ShouldAddRequestToDatabase()
        {
            var guid = Guid.NewGuid();

            var form = new RequestFormModel()
            {
                Id = guid,
                ManufacturerName = "The best manufacturer",
                ManufacturerDescription = "We are the best manufacturer ever",
                ManufacturerPhoneNumber = "+359888888888",
                ManufacturerAddress = "ul. Bulgaria",
                CityId = 1,
                UserEmail = "example@gmail.com"
            };

            await requestService.AddAsync(form);

            var request = await context.Requests.FindAsync(guid);
            Assert.IsNotNull(request);
        }

        [Test]
        public async Task DisapproveAsync_ShouldSetRequestToNotActive()
        {
            var guid = Guid.NewGuid();

            var form = new RequestFormModel()
            {
                Id = guid,
                ManufacturerName = "The best manufacturer",
                ManufacturerDescription = "We are the best manufacturer ever",
                ManufacturerPhoneNumber = "+359888888888",
                ManufacturerAddress = "ul. Bulgaria",
                CityId = 1,
                UserEmail = "example@gmail.com"
            };

            await requestService.AddAsync(form);
            await requestService.DisapproveAsync(guid);

            var requestIsActive = context.Requests.FindAsync(guid).Result!.IsActive;

            Assert.IsFalse(requestIsActive);
        }
    }
}
