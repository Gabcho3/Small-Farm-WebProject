using SmallFarm.Core.Models.Request;

namespace SmallFarm.Core.Contracts
{
    public interface IRequestService
    {
        Task AddAsync(RequestFormModel form);

        Task<bool> AlreadySendAsync(string email);
    }
}
