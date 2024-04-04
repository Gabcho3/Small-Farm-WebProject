﻿using Microsoft.EntityFrameworkCore;
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
            var userProducts = await cartService.GetAllProductsInCartAsync(clientId);
            userProducts = userProducts.ToList();

            var cartProducts = await context.Carts
                .Where(p => p.ClientId == clientId)
                .Include(cart => cart.Product)
                .ToListAsync();

            var order = new Order()
            {
                ClientId = clientId,
                OrderedDate = DateTime.Now,
                TotalPrice = cartProducts.Sum(p => p.Price),
            };

            await context.Orders.AddAsync(order);

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

                        var productOrder = new ProductOrder()
                        {
                            Order = order,
                            Product = cartProduct.Product,
                            Quantity = userProducts[j].Quantity
                        };

                        await context.ProductsOrders.AddAsync(productOrder);
                    }
                }
            };

            context.Carts.RemoveRange(cartProducts);

            await context.SaveChangesAsync();
        }
    }
}
