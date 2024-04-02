using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Core.Models.Request;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly SmallFarmDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper autoMapper;

        public ManufacturerService(SmallFarmDbContext _context, IMapper _autoMapper, UserManager<ApplicationUser> _userManager)
        {
            this.context = _context;
            this.autoMapper = _autoMapper;
            this.userManager = _userManager;
        }

        public async Task<ManufacturerFormModel?> GetManufacturerByIdAsync(Guid id)
        {
            var manufacturer = await context.Manufacturers
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

            var model = autoMapper.Map<ManufacturerFormModel>(manufacturer);

            return model;
        }

        public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync()
        {
            var allManufacturers = await context.Manufacturers
                .AsNoTracking()
                .Include(m => m.City)
                .OrderByDescending(m => m)
                .Select(m => autoMapper.Map<ManufacturerViewModel>(m))
                .ToListAsync();

            return allManufacturers;
        }

        public async Task<IEnumerable<CityViewModel>> GetAllCitiesAsync()
            => await context.Cities.AsNoTracking().Select(c => autoMapper.Map<CityViewModel>(c)).ToArrayAsync();

        public async Task AddManufacturerAsync(RequestFormModel model)
        {
            var userManufacturer = await userManager.FindByEmailAsync(model.UserEmail);
            await userManager.AddToRoleAsync(userManufacturer, "Manufacturer");

            Manufacturer manufacturer = new Manufacturer()
            {
                Id = Guid.Parse(userManufacturer.Id),
                Name = model.ManufacturerName,
                Description = model.ManufacturerDescription,
                Address = model.ManufacturerAddress,
                CityId = model.CityId,
                Email = model.UserEmail!,
                PhoneNumber = model.ManufacturerPhoneNumber
            };

            await context.AddAsync(manufacturer);
            await context.SaveChangesAsync();
        }

        public async Task EditManufacturerAsync(Guid id, ManufacturerFormModel model)
        {
            var manufacturerToEdit = await context.Manufacturers.FindAsync(id);

            manufacturerToEdit!.Name = model.Name;
            manufacturerToEdit.Description = model.Description;
            manufacturerToEdit.PhoneNumber = model.PhoneNumber;
            manufacturerToEdit.Email = model.Email;
            manufacturerToEdit.Address = model.Address;
            manufacturerToEdit.CityId = model.CityId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteManufacturerAsync(Guid id)
        {
            var manufacturerToDelete = await context.Manufacturers.FindAsync(id);
            var user = await context.Users.FirstAsync(u => u.Id == id.ToString());

            await userManager.RemoveFromRoleAsync(user, "Manufacturer");

            context.Manufacturers.Remove(manufacturerToDelete!);
            await context.SaveChangesAsync();
        }
    }
}
