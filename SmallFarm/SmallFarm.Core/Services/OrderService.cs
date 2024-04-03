using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Order;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly SmallFarmDbContext context;
        private readonly ICartService cartService;

        public OrderService(SmallFarmDbContext _context, ICartService cartService)
        {
            this.context = _context;
            this.cartService = cartService;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync(string clientId)
        {
            return await context.Orders
                .AsNoTracking()
                .Where(o => o.ClientId == clientId)
                .Select(o => new OrderViewModel()
                {
                    OrderedDate = o.OrderedDate,
                    TotalPrice = o.TotalPrice,
                    Products = o.Products
                        .Select(p => new ProductInOrderViewModel()
                        {
                            Id = p.Id,
                            Name = p.Name,
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task OrderAsync(string clientId)
        {
            var userProducts = await cartService.GetAllProductsInCartAsync(clientId);
            userProducts = userProducts.ToList();

            var cartProducts = await context.Carts
                .Where(p => p.ClientId == clientId)
                .Include(cart => cart.Product)
                .ToListAsync();

            foreach (var cartProduct in cartProducts)
            {
                for (int j = 0; j < userProducts.Count(); j++)
                {
                    if (cartProduct.Product.Name == userProducts[j].Name)
                    {
                        cartProduct.Product.Quantity -= userProducts[j].Quantity;

                        if (cartProduct.Product.Quantity == 0.0)
                        {
                            cartProduct.Product.IsActive = false;
                        }
                    }
                }
            };

            context.Carts.RemoveRange(cartProducts);

            context.Orders.Add(new Order()
            {
                ClientId = clientId,
                OrderedDate = DateTime.Now,
                TotalPrice = cartProducts.Sum(p => p.Price),
                Products = cartProducts.Select(p => p.Product).ToList()
            });

            await context.SaveChangesAsync();
        }
    }
}
