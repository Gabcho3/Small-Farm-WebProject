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
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2016/08/12/22/38/apple-1589874_1280.jpg"
                },

                new()
                {
                    Name = "Bananas",
                    Description = "Premium bananas, handpicked for freshness, delivered to your doorstep!",
                    CategoryId = 2,
                    Quantity = 20,
                    PricePerKg = 3.10m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2016/09/03/20/48/bananas-1642706_1280.jpg"
                },
                new()
                {
                    Name = "Cow milk",
                    Description = "Milk from domestic cow!",
                    CategoryId = 3,
                    Quantity = 25,
                    PricePerKg = 1.60m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2016/05/07/16/09/milk-1377564_1280.jpg"
                },
                new()
                {
                    Name = "Red Tomatoes",
                    Description = "Very delicious western bulgarian tomatoes!",
                    CategoryId = 1,
                    Quantity = 9,
                    PricePerKg = 3.30m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2022/09/05/09/50/tomatoes-7433786_1280.jpg"
                },
                new()
                {
                    Name = "Cucumbers",
                    Description = "Enjoy crisp cucumbers, harvested fresh and delivered conveniently to you!",
                    CategoryId = 1,
                    Quantity = 7,
                    PricePerKg = 1.90m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2015/07/17/13/44/cucumbers-849269_1280.jpg"
                },
                new()
                {
                    Name = "Small Potatoes",
                    Description = "Very delicious western bulgarian potatoes!",
                    CategoryId = 1,
                    Quantity = 12,
                    PricePerKg = 5.20m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://cdn.pixabay.com/photo/2014/08/06/20/32/potatoes-411975_1280.jpg"
                },
            };
        }
    }
}
