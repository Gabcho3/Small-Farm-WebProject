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
            return new()
            {
                new Location
                {
                    Id = 1,
                    Address = "123 Sunny Street",
                    City = "Veliko Tarnovo"
                },
                new Location
                {
                    Id = 2,
                    Address = "456 Dairy Lane",
                    City = "Rhodope Mountains"
                },
                new Location
                {
                    Id = 3,
                    Address = "789 Honey Farm Road",
                    City = "Rose Valley"
                }
            };
        }
    }
}
