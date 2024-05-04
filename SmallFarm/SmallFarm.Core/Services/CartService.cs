using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class CartService : ICartService
    {
        public readonly SmallFarmDbContext context;
        public readonly IMapper mapper;

        public CartService(SmallFarmDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        public int GetProductsInCartCount(string clientId)
        {
            return context.Carts
                .AsNoTracking()
                .Where(c => c.ClientId == clientId)
                .Select(p => p.ProductId)
                .Count();
        }

        public async Task<List<ProductToBuyModel>> GetAllProductsInCartAsync(string clientId)
        {
            return await context.Carts
                .AsNoTracking()
                .Where(c => c.ClientId == clientId && c.Product.IsActive)
                .Select(c => new ProductToBuyModel()
                {
                    Id = c.Product.Id,
                    Name = c.Product.Name,
                    Category = c.Product.Category.Name,
                    Description = c.Product.Description,
                    AvailableQuantity = c.Product.Quantity,
                    PricePerKg = c.Product.PricePerKg,
                    Image = c.Product.Image,
                    Manufacturer = c.Product.Manufacturer.Name,
                    Quantity = c.Quantity,
                    UserId = clientId,
                })
                .ToListAsync();
        }

        public async Task AddAsync(ProductToBuyModel model)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.ClientId == model.UserId && c.ProductId == model.Id);

            if (cart == null)
            {
                Cart cartToAdd = new Cart()
                {
                    ClientId = model.UserId,
                    ProductId = model.Id,
                    Quantity = model.Quantity,
                    Price = model.Total
                };

                await context.AddAsync(cartToAdd);
            }

            else
            {
                cart.Quantity = model.Quantity;
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId, string clientId)
        {
            Cart cartToRemove = await context.Carts.FirstAsync(c => c.ProductId == productId && c.ClientId == clientId);

            context.Remove(cartToRemove);
            await context.SaveChangesAsync();
        }
    }
}
