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
                    Description = "Very delicious western bulgarian apples!",
                    CategoryId = 2,
                    Quantity = 10,
                    PricePerKg = 3.90m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1576179635662-9d1983e97e1e?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },

                new()
                {
                    Name = "Bananas",
                    Description = "Very delicious western bulgarian bananas!",
                    CategoryId = 2,
                    Quantity = 20,
                    PricePerKg = 3.10m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1603833665858-e61d17a86224?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new()
                {
                    Name = "Cow milk",
                    Description = "Milk form domestic cow!",
                    CategoryId = 3,
                    Quantity = 25,
                    PricePerKg = 1.60m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1601436423474-51738541c1b1?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new()
                {
                    Name = "Big red tomatoes",
                    Description = "Very delicious western bulgarian tomatoes!",
                    CategoryId = 1,
                    Quantity = 9,
                    PricePerKg = 3.30m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1582284540020-8acbe03f4924?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new()
                {
                    Name = "Cucumbers",
                    Description = "Very delicious western bulgarian cucumbers!",
                    CategoryId = 1,
                    Quantity = 7,
                    PricePerKg = 1.90m,
                    ManufacturerId = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    ImageUrl =
                        "https://images.unsplash.com/photo-1449300079323-02e209d9d3a6?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
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
                        "https://images.unsplash.com/photo-1590165482129-1b8b27698780?q=80&w=1854&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
            };
        }
    }
}
