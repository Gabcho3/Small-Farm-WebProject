using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Data.Configurations
{
    public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(SeedIdentityUsers());
        }

        private static List<IdentityUser> SeedIdentityUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var admin = new IdentityUser()
            {
                UserName = Admin.Email,
                NormalizedUserName = Admin.Email.ToUpper(),
                Email = Admin.Email,
                NormalizedEmail = Admin.Email.ToUpper()
            };
            admin.PasswordHash = hasher.HashPassword(admin, "admin123");

            var manufacturer = new IdentityUser()
            {
                Id = "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                UserName = Manufacturer.Email,
                NormalizedUserName = Manufacturer.Email.ToUpper(),
                Email = Manufacturer.Email,
                NormalizedEmail = Manufacturer.Email.ToUpper()
            };
            manufacturer.PasswordHash = hasher.HashPassword(manufacturer, "manufacturer123");

            return new List<IdentityUser>() { admin, manufacturer };
        }
    }
}
