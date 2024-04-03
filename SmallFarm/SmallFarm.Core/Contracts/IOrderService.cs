namespace SmallFarm.Core.Contracts
{
    public interface IOrderService
    {
        Task OrderAsync(string clientId);
    }
}
