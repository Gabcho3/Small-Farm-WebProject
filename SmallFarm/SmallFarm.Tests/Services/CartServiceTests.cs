using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models.Product;
using SmallFarm.Core.Services;
using SmallFarm.Data;
using SmallFarm.Data.Entities;
using SmallFarm.Tests.Mocks;

namespace SmallFarm.Tests.Services
{
    [TestFixture]
    public class CartServiceTests
    {
        private SmallFarmDbContext context;
        private IMapper mapper;
        private ICartService cartService;

        private Product product;
        private ApplicationUser client;
        private ProductToBuyModel model;

        [SetUp]
        public async Task SetUp()
        {
            this.context = DatabaseMock.Instance;
            this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<SmallFarmProfile>()));
            this.cartService = new CartService(context, mapper);

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            this.product = await context.Products.FirstAsync(p => p.Name == "Cucumbers");
            this.client = await context.Users.FirstAsync(u => u.Email == "guest@gmail.com");

            this.model = mapper.Map<ProductToBuyModel>(this.product);
            this.model.UserId = client.Id;
        }

        [Test]
        public async Task AddAsync_ShouldAddNewCartIfProductNotExist()
        {
            await cartService.AddAsync(model);

            int productsCount =
                cartService.GetProductsInCartCount(client.Id);

            Assert.AreEqual(1, productsCount);
        }

        [Test]
        public async Task AddAsync_ShouldNotAddNewCartIfProductExist()
        {
            await cartService.AddAsync(model);
            await cartService.AddAsync(model);

            var cartCount = cartService.GetProductsInCartCount(client.Id);
            Assert.AreEqual(1, cartCount);
        }

        [Test]
        public async Task RemoveAsync_ShouldDeleteCart()
        {
            await cartService.AddAsync(model);
            await cartService.RemoveAsync(product.Id, client.Id);

            var cartCount = cartService.GetProductsInCartCount(client.Id);
            Assert.AreEqual(0, cartCount);
        }

        [Test]
        public async Task GetAllProductsInCartAsync_ShouldReturnAllCartProducts()
        {
            await cartService.AddAsync(model);

            var products = await cartService.GetAllProductsInCartAsync(client.Id);

            Assert.IsTrue(products.First().Id == product.Id);
        }
    }
}
