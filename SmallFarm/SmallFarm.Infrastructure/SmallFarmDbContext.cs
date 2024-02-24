using Microsoft.EntityFrameworkCore;

namespace SmallFarm.Data
{
    public class SmallFarmDbContext : DbContext
    {
        public SmallFarmDbContext(DbContextOptions<SmallFarmDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
