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
        private readonly IManufacturerService manufacturerService;

        public RequestService(SmallFarmDbContext _context, IMapper _mapper, UserManager<ApplicationUser> _userManager, IManufacturerService manufacturerService)
        {
            this.context = _context;
            this.mapper = _mapper;
            this.userManager = _userManager;
            this.manufacturerService = manufacturerService;
        }

        public async Task<List<RequestFormModel>> GetAllAsync()
        {
            return await context.Requests
                .Include(x => x.User)
                .Where(x => x.IsActive)
                .Select(x => mapper.Map<RequestFormModel>(x)).
                ToListAsync();
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

        public async Task ApproveAsync(Guid id)
        {
            var request = await context.Requests.Where(r => r.Id == id)
                .Include(r => r.User)
                .FirstAsync();
            request!.IsActive = false;

             var toAdd = mapper.Map<RequestFormModel>(request);

            await manufacturerService.AddManufacturerAsync(toAdd);

            await context.SaveChangesAsync();
        }

        public async Task DisapproveAsync(Guid id)
        {
            var request = await context.Requests.FindAsync(id);

            request!.IsActive = false;

            await context.SaveChangesAsync();
        }
    }
}
