using SmallFarm.Core.Models;

namespace SmallFarm.Core.Contracts
{
    public interface IManufacturerService
    {
        Task<ManufacturerViewModel> GetManufacturerByIdAsync(Guid id);

        Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();

        Task AddManufacturerAsync(ManufacturerViewModel model);

        Task EditManufacturerAsync(Guid id, ManufacturerViewModel model);
    }
}
