using AutoMapper;
using ProductCategoryDashBoard.Models;
using ProductCategoryDashBoard.ViewModels;

namespace ProductCategoryDashBoard.DBContext.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductsDto>().ReverseMap()
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                            .ForMember(dest => dest.ImageFileName, opt => opt.Ignore());


            CreateMap<Category, CategoryDto>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
