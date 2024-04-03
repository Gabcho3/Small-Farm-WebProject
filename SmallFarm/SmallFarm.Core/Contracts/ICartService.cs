using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface ICartService
    {
        int GetProductsInCartCount(string clientId);

        Task<List<ProductToBuyModel>> GetAllProductsInCartAsync(string clientId);

        Task AddAsync(ProductToBuyModel model);

        Task RemoveAsync(Guid productId, string clientId);
    }
}
