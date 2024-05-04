using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Helpers;
using SmallFarm.Core.Models.Product;
using SmallFarm.Core.Services;
using SmallFarm.Data;
using SmallFarm.Tests.Mocks;
using System;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace SmallFarm.Tests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        private SmallFarmDbContext context;
        private IMapper mapper;
        private IProductService productService;

        [SetUp]
        public async Task SetUp()
        {
            this.context = DatabaseMock.Instance;
            this.mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<SmallFarmProfile>()));
            this.productService = new ProductService(context, mapper);


            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnProductsByGivenCategory()
        {
            AllProductsQueryModel query = new AllProductsQueryModel()
            {
                Category = "Vegetables"
            };

            var model = await productService.GetAllAsync(query);
            var selectedProductsNames = model.Products.Select(p => p.Name).ToArray();

            var productsNames = await context.Products.Where(p => p.Category.Name == "Vegetables").Select(p => p.Name).ToArrayAsync();

            Assert.AreEqual(productsNames, selectedProductsNames);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnProductsByGivenSearchTerm()
        {
            AllProductsQueryModel query = new AllProductsQueryModel()
            {
                SearchTerm = "Cucumbers"
            };

            var model = await productService.GetAllAsync(query);
            var selectedProductsNames = model.Products.Select(p => p.Name).ToArray();

            var productsNames = await context.Products.Where(p => p.Name.Contains(query.SearchTerm)).Select(p => p.Name).ToArrayAsync();

            Assert.AreEqual(productsNames, selectedProductsNames);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnProductsByGivenPrice()
        {
            AllProductsQueryModel query = new AllProductsQueryModel()
            {
                MinPrice = 1,
                MaxPrice = 2
            };

            var model = await productService.GetAllAsync(query);
            var selectedProductsNames = model.Products.Select(p => p.Name).ToArray();

            var productsNames = await context.Products.Where(p => p.PricePerKg >= query.MinPrice && p.PricePerKg <= query.MaxPrice)
                .Select(p => p.Name)
                .ToArrayAsync();

            Assert.AreEqual(productsNames, selectedProductsNames);
        }

        [Test]
        public async Task AddAsync_ShouldAddProductToDatabase()
        {
            var manufacturerId = context.Manufacturers.First(m => m.Email == "manu@gmail.com").Id;
            
            var guid = Guid.NewGuid();

            var form = new ProductFormModel()
            {
                Id = guid,
                CategoryId = 1,
                Name = "Tomatoes",
                Image = new FormFile(Stream.Null, baseStreamOffset: 0, length: 0, name: string.Empty, fileName: string.Empty),
                PricePerKg = 10,
                Quantity = 10,
                ManufacturerId = manufacturerId
            };

            await productService.AddAsync(form);

            var product = await context.Products.FindAsync(guid);

            Assert.AreEqual(form.Name, product!.Name);
        }

        [Test]
        public async Task EditAsync_ShouldEditProduct()
        {
            var product = await context.Products.FirstAsync(p => p.Name == "Cucumbers");

            var form = new ProductFormModel()
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name + "Test",
                Image = new FormFile(Stream.Null, baseStreamOffset: 0, length: 0, name: string.Empty, fileName: string.Empty),
                PricePerKg = product.PricePerKg,
                Quantity = (decimal)product.Quantity,
                ManufacturerId = product.ManufacturerId
            };

            await productService.EditAsync(product.Id, form);

            var editedProduct = await context.Products.FindAsync(product.Id);
            Assert.AreEqual(form.Name, editedProduct!.Name);
        }

        [Test]
        public async Task RemoveAsync_ShouldRemoveProduct()
        {
            var productId = context.Products.First(p => p.Name == "Cucumbers").Id;
            var manuId = context.Manufacturers.First(m => m.Email == "manu@gmail.com").Id;

            await productService.RemoveAsync(productId, manuId);

            var product = await context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            Assert.IsNull(product);
        }
    }
}
