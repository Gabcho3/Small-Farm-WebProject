using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Common.DataConstants;

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
                UserName = AdministratorConstants.AdminEmail,
                NormalizedUserName = AdministratorConstants.AdminEmail.ToUpper(),
                Email = AdministratorConstants.AdminEmail,
                NormalizedEmail = AdministratorConstants.AdminEmail.ToUpper()
            };

            admin.PasswordHash = hasher.HashPassword(admin, "admin123");

            return new List<IdentityUser>() { admin };
        }
    }
}
