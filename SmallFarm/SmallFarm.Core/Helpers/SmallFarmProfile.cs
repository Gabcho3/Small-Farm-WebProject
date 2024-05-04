using AutoMapper;
using SmallFarm.Core.Models.City;
using SmallFarm.Core.Models.Manufacturer;
using SmallFarm.Core.Models.Product;
using SmallFarm.Core.Models.Request;
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
            CreateMap<ProductFormModel, Product>()
                .ForMember(dest => dest.Image, opt => opt.Ignore());
            CreateMap<Product, ProductFormModel>();

            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Price,
                    opt => opt.MapFrom(src => src.PricePerKg));

            CreateMap<Product, ProductToBuyModel>()
                .ForMember(dest => dest.Manufacturer,
                    opt => opt.MapFrom(src => src.Manufacturer.Name))
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.AvailableQuantity,
                    opt => opt.MapFrom(src => src.Quantity));

            //Requests
            CreateMap<RequestFormModel, Request>();

            CreateMap<Request, RequestFormModel>()
                .ForMember(dest => dest.UserEmail,
                    opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
