using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Data.Configurations;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data
{
    public class SmallFarmDbContext : IdentityDbContext<ApplicationUser>
    {
        public SmallFarmDbContext(DbContextOptions<SmallFarmDbContext> options) 
            : base(options) { }

        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        public DbSet<Request> Requests { get; set; } = null!;

        public override DbSet<ApplicationUser> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasKey(x => new { x.ClientId, x.ProductId });

            builder.Entity<OrderProduct>()
                .HasKey(x => new { x.OrderId, x.ProductId });


            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new ManufacturersConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
