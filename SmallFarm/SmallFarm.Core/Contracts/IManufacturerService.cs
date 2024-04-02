using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Core.Models.Request;

namespace SmallFarm.Core.Contracts
{
    public interface IManufacturerService
    {
        Task<ManufacturerFormModel?> GetManufacturerByIdAsync(Guid id);

        Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();

        Task<IEnumerable<CityViewModel>> GetAllCitiesAsync();

        Task AddManufacturerAsync(RequestFormModel model);

        Task EditManufacturerAsync(Guid id, ManufacturerFormModel model);

        Task DeleteManufacturerAsync(Guid id);
    }
}
