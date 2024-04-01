using Microsoft.AspNetCore.Identity;
using SmallFarm.Common.DataConstants;
using SmallFarm.Data.Entities;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> SeedRoles(this IApplicationBuilder app)
        {
            await app.SeedRole(Admin.RoleName, Admin.Email);
            await app.SeedRole(RoleConstants.Manufacturer.RoleName, RoleConstants.Manufacturer.Email);

            return app;
        }


        private static async Task SeedRole(this IApplicationBuilder app, string roleName, string userEmail)
        {
            await using var scopedServices = app.ApplicationServices.CreateAsyncScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.RoleExistsAsync(roleName))
            {
                return;
            }

            var role = new IdentityRole(roleName);

            await roleManager.CreateAsync(role);

            var user = await userManager.FindByEmailAsync(userEmail);

            await userManager.AddToRoleAsync(user, role.Name);
        }
    }
}
