using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface IProductService
    {
        Task<ProductToBuyModel> GetByIdAsync(Guid productId);

        Task<ProductQueryModel> GetAllAsync(AllProductsQueryModel queryModel);

        Task AddAsync(ProductFormModel productForm);
    }
}
