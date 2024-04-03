using SmallFarm.Core.Models.Order;

namespace SmallFarm.Core.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetOrdersAsync(string clientId);

        Task OrderAsync(string clientId);
    }
}
