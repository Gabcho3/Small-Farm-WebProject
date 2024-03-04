using AutoMapper;
using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Helpers
{
    public class SmallFarmProfile : Profile
    {
        public SmallFarmProfile()
        {
            //Manufacturer and ManufacturerFormModel
            CreateMap<Manufacturer, ManufacturerFormModel>();
            CreateMap<ManufacturerFormModel, Manufacturer>();

            //Manufacturer and ManufacturerViewModel
            CreateMap<Manufacturer, ManufacturerViewModel>()
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.City.Name));

            //Cities
            CreateMap<City, CityDto>();
        }
    }
}
