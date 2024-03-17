using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly SmallFarmDbContext context;

        private readonly IMapper mapper;

        public ProductService(SmallFarmDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            return await context.Products.AsNoTracking()
                .Include(p => p.Manufacturer)
                .Select(p => mapper.Map<ProductViewModel>(p))
                .ToArrayAsync();
        }

        public async Task AddAsync(ProductFormModel productForm)
        {
            var productToAdd = mapper.Map<Product>(productForm);

            await context.AddAsync(productToAdd);
            await context.SaveChangesAsync();
        }
    }
}
