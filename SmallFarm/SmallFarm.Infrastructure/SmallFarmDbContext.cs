using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Data.Entities;

namespace SmallFarm.Data
{
    public class SmallFarmDbContext : IdentityDbContext<IdentityUser>
    {
        public SmallFarmDbContext(DbContextOptions<SmallFarmDbContext> options) 
            : base(options) { }

        public DbSet<Location> Locations { get; set; } = null!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderProduct> OrderProducts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cart>()
                .HasKey(c => new { c.ProductId, c.ClientId });

            builder.Entity<OrderProduct>()
                .HasKey(x => new { x.OrderId, x.ProductId });

            base.OnModelCreating(builder);
        }
    }
}
