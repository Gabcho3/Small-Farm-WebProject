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
            return new List<Manufacturer>()
            {
                new Manufacturer()
                {
                    Id = Guid.NewGuid(),
                    Name = "BestProducts EOD",
                    Address = "Todor Kableshkov 1",
                    CityId = 1,
                    Description = "Our farm is one of the best on the market!",
                    Email = "manu@gmail.com",
                    PhoneNumber = "+359882228888"
                },
            };
        }
    }
}
