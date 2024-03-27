using Microsoft.AspNetCore.Identity;
using static SmallFarm.Common.DataConstants.RoleConstants;

namespace SmallFarm.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> SeedRoles(this IApplicationBuilder app)
        {
            await app.SeedRole(Admin.RoleName, Admin.Email);
            await app.SeedRole(Manufacturer.RoleName, Manufacturer.Email);

            return app;
        }


        private static async Task SeedRole(this IApplicationBuilder app, string roleName, string userEmail)
        {
            await using var scopedServices = app.ApplicationServices.CreateAsyncScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
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
