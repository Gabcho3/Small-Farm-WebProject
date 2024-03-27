using Microsoft.AspNetCore.Identity;
using static SmallFarm.Common.DataConstants.AdministratorConstants;

namespace SmallFarm.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder?> SeedAdmin(this IApplicationBuilder app)
        {
            await using var scopedServices = app.ApplicationServices.CreateAsyncScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (await roleManager.RoleExistsAsync(AdminRoleName))
            {
                return app;
            }

            var role = new IdentityRole(AdminRoleName);

            await roleManager.CreateAsync(role);

            var admin = await userManager.FindByEmailAsync(AdminEmail);

            await userManager.AddToRoleAsync(admin, role.Name);

            return app;
        }
    }
}
