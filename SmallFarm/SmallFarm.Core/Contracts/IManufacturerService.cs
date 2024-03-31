using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;

namespace SmallFarm.Core.Contracts
{
    public interface IManufacturerService
    {
        Task<ManufacturerFormModel?> GetManufacturerByIdAsync(Guid id);

        Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();

        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();

        Task AddManufacturerAsync(ManufacturerFormModel model);

        Task EditManufacturerAsync(Guid id, ManufacturerFormModel model);

        Task DeleteManufacturerAsync(Guid id);
    }
}
