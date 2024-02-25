using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Data;

namespace SmallFarm.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<SmallFarmDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static void AddApplicationIdentity(this IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                })
                .AddEntityFrameworkStores<SmallFarmDbContext>();
        }
    }
}
