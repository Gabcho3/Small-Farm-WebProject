using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data.Configurations
{
    internal class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(SeedLocations());
        }

        private static List<Location> SeedLocations()
        {
            return new();
        }
    }
}
