using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using SmallFarm.Core.Models.ProductCategory;
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

        public async Task<T> GetByIdAsync<T>(Guid productId)
            => mapper.Map<T>(await context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .FirstAsync(p => p.Id == productId));

        public async Task<ProductQueryModel> GetAllAsync(AllProductsQueryModel queryModel)
        {
            var result = new ProductQueryModel();

            var products = context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .AsQueryable();

            if (!string.IsNullOrEmpty(queryModel.Category))
            {
                products = products.Where(p => p.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrEmpty(queryModel.SearchTerm))
            {
                var searchTerm = $"%{queryModel.SearchTerm.ToLower()}%";

                products = products
                    .Where(p => EF.Functions.Like(p.Name.ToLower(), searchTerm) ||
                                EF.Functions.Like(p.Manufacturer.Name.ToLower(), searchTerm));
            }

            if (queryModel.MinPrice >= 0 && queryModel.MaxPrice > 0)
            {
                products = products.Where(p => p.PricePerKg >= queryModel.MinPrice && p.PricePerKg <= queryModel.MaxPrice);
            }

            products = (int)queryModel.Sorting switch
            {
                1 => products.OrderByDescending(p => p.PricePerKg),
                2 => products.OrderBy(p => p.Quantity),
                3 => products.OrderByDescending(p => p.Quantity),
                _ => products.OrderBy(p => p.PricePerKg),
            };

            result.Products = await products
                .Skip((queryModel.CurrentPage - 1) * 4)
                .Take(4)
                .Select(p => mapper.Map<ProductViewModel>(p))
                .ToListAsync();

            result.TotalProductsCount = await products.CountAsync();

            return result;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllCategoriesAsync()
        {
            return await context.ProductCategories
                .AsNoTracking()
                .Select(p => new ProductCategoryViewModel() { Id = p.Id, Name = p.Name })
                .ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetRandomProductsAsync()
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Manufacturer)
                .Where(p => p.IsActive)
                .OrderByDescending(x => x.Id)
                .Select(p => mapper.Map<ProductViewModel>(p))
                .Take(5)
                .ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetManufacturerProductsAsync(string nameOrEmail)
        {
            return await context.Products
                .AsNoTracking()
                .Include(p => p.Manufacturer)
                .Include(p => p.Category)
                .Where(p => p.Manufacturer.Email == nameOrEmail || p.Manufacturer.Name == nameOrEmail)
                .OrderByDescending(x => !x.IsActive)
                .ThenBy(x => x.Name)
                .Select(p => mapper.Map<ProductViewModel>(p))
                .ToListAsync();
        }

        public async Task AddAsync(ProductFormModel productForm)
        {
            var productToAdd = mapper.Map<Product>(productForm);

            await context.AddAsync(productToAdd);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(Guid id, ProductFormModel productForm)
        {
            var productToEdit = await context.Products.FindAsync(id);

            productToEdit!.Name = productForm.Name!;
            productToEdit.Description = productForm.Description;
            productToEdit.PricePerKg = productForm.PricePerKg;
            productToEdit.ImageUrl = productForm.ImageUrl;
            productToEdit.Quantity = (double)productForm.Quantity;
            productToEdit.CategoryId = productForm.CategoryId;

            productToEdit.IsActive = true;

            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var productToRemove = await context.Products.FindAsync(id);

            context.Products.Remove(productToRemove);
            await context.SaveChangesAsync();
        }
    }
}

