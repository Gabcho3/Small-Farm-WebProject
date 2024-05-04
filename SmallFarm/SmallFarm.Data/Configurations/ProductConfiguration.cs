using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(SeedProducts());
        }

        private static List<Product> SeedProducts()
        {
            return new List<Product>()
            {
                new()
                {
                    Name = "Red Apples",
                    Description = "Fresh, handpicked red apples delivered straight to your doorstep!",
                    CategoryId = 2,
                    Quantity = 10,
                    PricePerKg = 3.90m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/apples.jpg")
                },

                new()
                {
                    Name = "Bananas",
                    Description = "Premium bananas, handpicked for freshness, delivered to your doorstep!",
                    CategoryId = 2,
                    Quantity = 20,
                    PricePerKg = 3.10m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/bananas.jpg")
                },
                new()
                {
                    Name = "Cow milk",
                    Description = "Milk from domestic cow!",
                    CategoryId = 3,
                    Quantity = 25,
                    PricePerKg = 1.60m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/milk.jpg")
                },
                new()
                {
                    Name = "Red Tomatoes",
                    Description = "Very delicious western bulgarian tomatoes!",
                    CategoryId = 1,
                    Quantity = 9,
                    PricePerKg = 3.30m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/tomatoes.jpg")
                },
                new()
                {
                    Name = "Cucumbers",
                    Description = "Enjoy crisp cucumbers, harvested fresh and delivered conveniently to you!",
                    CategoryId = 1,
                    Quantity = 7,
                    PricePerKg = 1.90m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/cucumbers.jpg")
                },
                new()
                {
                    Name = "Small Potatoes",
                    Description = "Very delicious western bulgarian potatoes!",
                    CategoryId = 1,
                    Quantity = 12,
                    PricePerKg = 5.20m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Image = File.ReadAllBytes("../SmallFarm/wwwroot/Images/potatoes.jpg")
                },
            };
        }
    }
}
