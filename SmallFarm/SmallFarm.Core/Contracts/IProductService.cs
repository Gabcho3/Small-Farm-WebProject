using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();

        Task AddAsync(ProductFormModel productForm);
    }
}
