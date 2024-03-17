using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface IProductService
    {
        Task<ProductToBuyModel> GetProductById(Guid productId);

        Task<IEnumerable<ProductViewModel>> GetProductsAsync();

        Task AddAsync(ProductFormModel productForm);
    }
}
