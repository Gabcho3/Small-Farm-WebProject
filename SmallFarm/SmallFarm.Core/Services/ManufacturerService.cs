using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly SmallFarmDbContext context;
        private readonly IMapper autoMapper;

        public ManufacturerService(SmallFarmDbContext _context)
        {
            this.context = _context;
            this.autoMapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SmallFarmProfile>();
            }));
        }

        public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync()
        {
            var allManufacturers = await context.Manufacturers
                .Include(m => m.Location)
                .OrderByDescending(m => m)
                .Select(m => autoMapper.Map<ManufacturerViewModel>(m))
                .ToListAsync();

            return allManufacturers;
        }

        public async Task AddManufacturerAsync(ManufacturerViewModel model)
        {
            Manufacturer manufacturer = autoMapper.Map<Manufacturer>(model);
            manufacturer.Location = new Location()
            {
                Address = model.Address,
                City = model.City
            };

            await context.AddAsync(manufacturer);
            await context.SaveChangesAsync();
        }
    }
}
