using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmallFarm.Common.DataConstants;
using SmallFarm.Data.Entities;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedApplicationUsers());
        }

        private static List<ApplicationUser> SeedApplicationUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var admin = new ApplicationUser()
            {
                FirstName = "Gabriel",
                LastName = "Dimitrov",
                UserName = Admin.Email,
                NormalizedUserName = Admin.Email.ToUpper(),
                Email = Admin.Email,
                NormalizedEmail = Admin.Email.ToUpper()
            };
            admin.PasswordHash = hasher.HashPassword(admin, "admin123");

            var manufacturer = new ApplicationUser()
            {
                FirstName = "Ivan",
                LastName = "Dragiev",
                Id = "f61b7997-5b5b-4b60-89f2-eba32d1a3d29",
                UserName = RoleConstants.Manufacturer.Email,
                NormalizedUserName = RoleConstants.Manufacturer.Email.ToUpper(),
                Email = RoleConstants.Manufacturer.Email,
                NormalizedEmail = RoleConstants.Manufacturer.Email.ToUpper()
            };
            manufacturer.PasswordHash = hasher.HashPassword(manufacturer, "manufacturer123");

            var manu = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "example@gmail.com",
                UserName = "example@gmail.com",
                NormalizedEmail = "example@gmail.com".ToUpper(),
                NormalizedUserName = "example@gmail.com".ToUpper()
            };
            manu.PasswordHash = hasher.HashPassword(manu, "example123");

            var guest = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Todor",
                LastName = "Ivanov",
                Email = "guest@gmail.com",
                UserName = "guest@gmail.com",
                NormalizedEmail = "guest@gmail.com".ToUpper(),
                NormalizedUserName = "guest@gmail.com".ToUpper()
            };
            guest.PasswordHash = hasher.HashPassword(guest, "guest123");

            return new List<ApplicationUser>() { admin, manufacturer, guest, manu };
        }
    }
}
