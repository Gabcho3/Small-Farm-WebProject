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
                    Id = Guid.Parse("f61b7997-5b5b-4b60-89f2-eba32d1a3d29"),
                    Name = "BestProducts OOD",
                    Address = "bul. Todor Kableshkov",
                    CityId = 1,
                    Description = "We are one of the best on the market!",
                    Email = "manu@gmail.com",
                    PhoneNumber = "+359885118198"
                }
            };
        }
    }
}
