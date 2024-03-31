using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data.Configurations
{
    internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(SeedCategories());
        }

        private static List<ProductCategory> SeedCategories()
        {
            return new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Id = 1,
                    Name = "Vegetable"
                },
                new ProductCategory()
                {
                    Id = 2,
                    Name = "Fruit"
                },
                new ProductCategory()
                {
                    Id = 3,
                    Name = "Drink"
                }
            };
        }
    }
}
