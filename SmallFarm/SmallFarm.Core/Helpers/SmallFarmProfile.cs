using AutoMapper;
using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Core.Models.Product;
using SmallFarm.Data.Entities;

namespace SmallFarm.Core.Helpers
{
    public class SmallFarmProfile : Profile
    {
        public SmallFarmProfile()
        {
            //Manufacturer
            CreateMap<Manufacturer, ManufacturerFormModel>();
            CreateMap<ManufacturerFormModel, Manufacturer>();
            CreateMap<Manufacturer, ManufacturerViewModel>()
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.City.Name));

            //Cities
            CreateMap<City, CityViewModel>();

            //Products
            CreateMap<ProductFormModel, Product>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(src => src.Manufacturer.Name));
            CreateMap<Product, ProductToBuyModel>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.AvailableQuantity,
                    opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PricePerKg,
                    opt => opt.MapFrom(src => src.Price));

        }
    }
}
