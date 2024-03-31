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

        public CartService(SmallFarmDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<ProductToBuyModel>> GetAllProductsInCartAsync(string clientId)
        {
            return await context.Carts
                .AsNoTracking()
                .Where(c => c.ClientId == clientId)
                .Select(c => new ProductToBuyModel()
                {
                    Id = c.Product.Id,
                    Name = c.Product.Name,
                    Description = c.Product.Description,
                    AvailableQuantity = c.Product.Quantity,
                    PricePerKg = c.Product.PricePerKg,
                    ImageUrl = c.Product.ImageUrl,
                    Manufacturer = c.Product.Manufacturer.Name,
                    Quantity = c.Quantity,
                    UserId = clientId,
                })
                .ToArrayAsync();
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

        public async Task RemoveAsync(Guid productId, string userId)
        {
            Cart cartToRemove = await context.Carts.FirstAsync(c => c.ProductId == productId && c.ClientId == userId);

            context.Remove(cartToRemove);
            await context.SaveChangesAsync();
        }
    }
}
