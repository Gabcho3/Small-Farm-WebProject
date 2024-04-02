using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmallFarm.Core.Contracts;
using SmallFarm.Core.Models.Request;
using SmallFarm.Data;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly SmallFarmDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public RequestService(SmallFarmDbContext _context, IMapper _mapper, UserManager<ApplicationUser> _userManager)
        {
            this.context = _context;
            this.mapper = _mapper;
            this.userManager = _userManager;
        }

        public async Task AddAsync(RequestFormModel form)
        {
            var request = mapper.Map<Request>(form);
            request.User = userManager.Users.First(u => u.Email == form.UserEmail);

            await context.Requests.AddAsync(request);
            await context.SaveChangesAsync();
        }

        public async Task<bool> AlreadySendAsync(string email)
        {
            return await context.Requests
                .Where(r => r.IsActive)
                .FirstOrDefaultAsync(r => r.User.Email == email) != null;
        }
    }
}
