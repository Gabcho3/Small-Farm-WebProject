using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models;
using SmallFarm.Data;

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
                .Select(m => autoMapper.Map<ManufacturerViewModel>(m))
                .ToListAsync();

            return allManufacturers;
        }
    }
}
