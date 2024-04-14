using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Services;
using SmallFarm.Data;
using SmallFarm.Data.Entities;
using SmallFarm.Tests.Mocks;

namespace SmallFarm.Tests.Services
{
    [TestFixture]
    public class OrderServiceTests
    {
        private SmallFarmDbContext context;
        private IOrderService orderService;

        private ApplicationUser user;
        private Product product;

        [SetUp]
        public async Task SetUp()
        {
            this.context = DatabaseMock.Instance;
            this.orderService = new OrderService(context);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            this.user = await context.Users.FirstAsync(u => u.Email == "guest@gmail.com");
            this.product = await context.Products.FirstAsync(p => p.Name == "Cucumbers");

            await context.Carts.AddAsync(new Cart()
            {
                Client = user,
                Product = product,
                Quantity = 3,
                Price = product.PricePerKg * (decimal)product.Quantity
            });
            await context.SaveChangesAsync();
        }

        [Test]
        public async Task OrderAsync_ShouldIncreaseProductsQuantityAndAddProduct()
        {
            var expectedQuantity = this.product.Quantity - 3;

            await orderService.OrderAsync(user.Id);

            var order = await context.Orders.FirstAsync(o => o.ClientId == user.Id);

            Assert.IsNotNull(order);
            Assert.AreEqual(expectedQuantity, product.Quantity);
        }

        [Test]
        public async Task ConfirmAsync_ShouldSetOrderToNotActive()
        {
            await orderService.OrderAsync(user.Id);

            var order = await context.Orders.FirstAsync(o => o.ClientId == user.Id);

            await orderService.ConfirmAsync(order.Id);

            Assert.IsFalse(order.IsActive);
        }
    }
}
