using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data.Configurations
{
    internal class ManufacturersConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(SeedManufacturers());
        }

        private static List<Manufacturer> SeedManufacturers()
        {
            return new()
            {
                new Manufacturer
                {
                    Name = "Sunny Valley Farms",
                    Description =
                        "Sunny Valley Farms is a family-owned agricultural business located in the heart of Bulgaria's fertile countryside near Veliko Tarnovo. Specializing in organic fruit and vegetable production, we pride ourselves on delivering the freshest, highest-quality produce to local markets and restaurants. From juicy peaches to crisp cucumbers, our farm-fresh offerings are sure to delight your taste buds.",
                    PhoneNumber = "+359 62 123 456",
                    Email = "info@sunnyvalleyfarms.bg",
                    LocationId = 1
                },
                new Manufacturer
                {
                    Name = "Balkan Dairy Co-op",
                    Description =
                        "Balkan Dairy Co-op is a cooperative of small-scale dairy farmers located in the picturesque Rhodope Mountains of Bulgaria. Our passionate farmers work tirelessly to produce the finest organic dairy products, including creamy yogurt, artisanal cheeses, and rich, velvety milk. With a commitment to sustainability and animal welfare, we strive to provide wholesome, nutritious dairy products straight from our pastures to your table.",
                    PhoneNumber = "+359 88 765 4321",
                    Email = "info@balkandairycoop.com",
                    LocationId = 2
                },
                new Manufacturer
                {
                    Name = "Golden Fields Honey",
                    Description =
                        "Golden Fields Honey is a beekeeping enterprise nestled in the sun-drenched valleys of Bulgaria's Rose Valley region. Our beekeepers lovingly tend to our hives, ensuring that our pure, raw honey captures the essence of Bulgaria's diverse floral landscapes. From fragrant acacia honey to robust wildflower varieties, each jar of Golden Fields Honey is a testament to nature's bounty and our dedication to artisanal craftsmanship.",
                    PhoneNumber = "+359 31 234 567",
                    Email = "sales@goldenfieldshoney.bg",
                    LocationId = 3
                }
            };
        }
    }
}
