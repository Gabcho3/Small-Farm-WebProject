using SmallFarm.Core.Models.Request;

namespace SmallFarm.Core.Contracts
{
    public interface IRequestService
    {
        Task<List<RequestFormModel>> GetAllAsync();

        Task AddAsync(RequestFormModel form);

        Task<bool> AlreadySendAsync(string email);

        Task ApproveAsync(Guid id);
    }
}
