using SmallFarm.Core.Models;

namespace SmallFarm.Core.Contracts
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();

        Task AddManufacturerAsync(ManufacturerViewModel model);
    }
}
