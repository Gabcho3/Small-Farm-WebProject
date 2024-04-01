using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly SmallFarmDbContext context;

        public ApplicationUserService(SmallFarmDbContext _context)
        {
            this.context = _context;
        }

        public string GetFullName(string email)
        {
            var user = context.Users
                .First(u => u.Email == email);

            return user.FirstName + " " + user.LastName;
        }

        public string GetManufacturerName(string email)
        {
            var manufacturer = context.Manufacturers
                .First(u => u.Email == email);

            return manufacturer.Name;
        }
    }
}
