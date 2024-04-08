using SmallFarm.Core.Models.Product;
using SmallFarm.Core.Models.ProductCategory;

namespace SmallFarm.Core.Contracts
{
    public interface IProductService
    {
        Task<ProductToBuyModel> GetByIdAsync(Guid productId);

        Task<ProductFormModel> GetManufacturerProductById(Guid productId, string userId);

        Task<ProductQueryModel> GetAllAsync(AllProductsQueryModel queryModel);

        Task<List<ProductCategoryViewModel>> GetAllCategoriesAsync();

        Task<List<ProductViewModel>> GetRandomProductsAsync();

        Task<List<ProductViewModel>> GetManufacturerProductsAsync(string name);


        Task AddAsync(ProductFormModel productForm);

        Task EditAsync(Guid id, ProductFormModel productForm);

        Task RemoveAsync(Guid id, Guid userId);
    }
}
