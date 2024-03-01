using AutoMapper;
using SmallFarm.Core.Models;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Helpers
{
    public class SmallFarmProfile : Profile
    {
        public SmallFarmProfile()
        {
            CreateMap<Manufacturer, ManufacturerViewModel>()
                .ForMember(dest => dest.Address,
                    opt => opt.MapFrom(src => src.Location.Address))
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.Location.City));

            CreateMap<ManufacturerViewModel, Manufacturer>();
        }
    }
}
