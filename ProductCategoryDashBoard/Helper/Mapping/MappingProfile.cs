using AutoMapper;
//using ProductCategoryDashBoard.Models;
using ProductCategoryDashBoard.ViewModels;
using DashBoard.DAL.Models;
using DashBoard.PL.ViewModels;


namespace ProductCategoryDashBoard.Helper.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Products, ProductsDto>().ReverseMap()
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                            .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                            .ForMember(dest => dest.ImageFileName, opt => opt.Ignore());


            CreateMap<Category, CategoryDto>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                            .ForMember(dest => dest.Descrption, opt => opt.MapFrom(src => src.Descrption))
                            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                            .ForMember(dest => dest.ImageFileName, opt => opt.Ignore());


            CreateMap<SubCategory, SubCategoryDto>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Offers, OffersDto>().ReverseMap()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                            .ForMember(dest => dest.Descrption, opt => opt.MapFrom(src => src.Descrption))
                            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                            .ForMember(dest => dest.OfferType, opt => opt.MapFrom(src => src.OfferType))
                            .ForMember(dest => dest.TermsConditions, opt => opt.MapFrom(src => src.TermsConditions))
                            .ForMember(dest => dest.ImageFileName, opt => opt.Ignore());
        }
    }
}
