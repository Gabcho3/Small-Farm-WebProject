using SmallFarm.Core.Models.Order;

namespace SmallFarm.Core.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewModel>> GetOrdersAsync(string id);

        Task<List<OrderViewModel>> GetManufacturerOrdersAsync(string id);

        Task OrderAsync(string clientId);

        Task ConfirmAsync(Guid id);
    }
}
