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

        public OrderService(SmallFarmDbContext _context)
        {
            this.context = _context;
        }

        public async Task<List<OrderViewModel>> GetOrdersAsync(string id)
        {
            return await context.Orders
                .AsNoTracking()
                .Where(o => o.ClientId == id)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Contacts = o.Manufacturer.PhoneNumber + ", " + o.Manufacturer.Name,
                    OrderedDate = o.OrderedDate,
                    TotalPrice = o.TotalPrice,
                    IsActive = o.IsActive,
                    Products = o.ProductsOrders
                        .Select(x => new ProductInOrderViewModel()
                        {
                            Id = x.ProductId,
                            Name = x.Product.Name,
                            Quantity = x.Quantity,
                            Price = x.Product.PricePerKg
                        })
                        .ToList()
                })
                .OrderBy(o => o.OrderedDate)
                .ToListAsync();
        }

        public async Task<List<OrderViewModel>> GetManufacturerOrdersAsync(string id)
        {
            return await context.Orders
                .AsNoTracking()
                .Where(o => o.ManufacturerId == Guid.Parse(id) && o.IsActive)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Contacts = o.Client.PhoneNumber + ", " + o.Client.FirstName + " " + o.Client.LastName,
                    OrderedDate = o.OrderedDate,
                    TotalPrice = o.TotalPrice,
                    IsActive = o.IsActive,
                    Products = o.ProductsOrders
                        .Select(x => new ProductInOrderViewModel()
                        {
                            Id = x.ProductId,
                            Name = x.Product.Name,
                            Quantity = x.Quantity,
                            Price = x.Product.PricePerKg
                        })
                        .ToList()
                })
                .OrderBy(o => o.OrderedDate)
                .ToListAsync();
        }

        public async Task OrderAsync(string clientId)
        {
            var cartProducts = await context.Carts
                .Where(p => p.ClientId == clientId)
                .Include(cart => cart.Product)
                .ToListAsync();

            var order = new Order()
            {
                ClientId = clientId,
                ManufacturerId = cartProducts.First().Product.ManufacturerId,
                OrderedDate = DateTime.Now,
                TotalPrice = cartProducts.Sum(p => p.Price),
                IsActive = true
            };

            await context.Orders.AddAsync(order);

            foreach (var cartProduct in cartProducts)
            {
                cartProduct.Product.Quantity -= cartProduct.Quantity;

                if (cartProduct.Product.Quantity == 0.0)
                {
                    cartProduct.Product.IsActive = false;
                }

                var productOrder = new ProductOrder()
                {
                    Order = order,
                    Product = cartProduct.Product,
                    Quantity = cartProduct.Quantity
                };

                await context.ProductsOrders.AddAsync(productOrder);
            };

            context.Carts.RemoveRange(cartProducts);

            await context.SaveChangesAsync();
        }

        public async Task ConfirmAsync(Guid id)
        {
            var orderToConfirm = await context.Orders.FindAsync(id);

            orderToConfirm!.IsActive = false;

            await context.SaveChangesAsync();
        }
    }
}
