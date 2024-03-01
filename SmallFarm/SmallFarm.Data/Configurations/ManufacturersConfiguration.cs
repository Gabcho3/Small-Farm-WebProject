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
            return new();
        }
    }
}
