using SmallFarm.Core.Models.Product;

namespace SmallFarm.Core.Contracts
{
    public interface IProductService
    {
        Task AddAsync(ProductFormModel productForm);
    }
}
