using Microsoft.EntityFrameworkCore;
using SmallFarm.Data;

namespace SmallFarm.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static SmallFarmDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<SmallFarmDbContext>()
                    .UseInMemoryDatabase("SmallFarm")
                    .Options;

                return new SmallFarmDbContext(dbContextOptions);
            }
        }
    }
}
