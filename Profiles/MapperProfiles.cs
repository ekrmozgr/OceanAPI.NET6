using AutoMapper;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Basket, BasketDto>();

            CreateMap<BasketProduct, BasketProductReadDto>();
            
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

            CreateMap<User, UserInProductReadDto>();

            CreateMap<Product, ProductReadDto>()
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.ProductCategory.GetDisplayName()))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(a => a.CourseLevel.GetDisplayName()));
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(p => p.ProductCategory, x=> x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(pu => (ECourseLevel)pu.CourseLevelId));
            CreateMap<ProductCreateDto, Product>()
                .ForMember(p => p.ProductCategory, x => x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(pu => (ECourseLevel)pu.CourseLevelId));

            CreateMap<Product, ProductCreateDto>();

            CreateMap<FAQCategory,FaqReadDto>()
                .ForMember(fr => fr.FaqCategoryName, fc => fc.MapFrom(f => f.FaqCategory.GetDisplayName()));

            CreateMap<ProductCategory, EnumOptionReadDto>()
                .ForMember(p => p.OptionName, x => x.MapFrom(a => a.ProductCategorys.GetDisplayName()))
                .ForMember(p => p.OptionId, x => x.MapFrom(a => a.ProductCategoryId));
            CreateMap<CourseLevel, EnumOptionReadDto>()
                .ForMember(p => p.OptionName, x => x.MapFrom(a => a.ECourseLevel.GetDisplayName()))
                .ForMember(p => p.OptionId, x => x.MapFrom(a => a.CourseLevelId));
            CreateMap<Role, EnumOptionReadDto>()
                .ForMember(p => p.OptionName, x => x.MapFrom(a => a.ERole.GetDisplayName()))
                .ForMember(p => p.OptionId, x => x.MapFrom(a => a.RoleId));

            CreateMap<Comments, CommentsReadDto>();
            CreateMap<CommentsCreateDto, Comments>();
            CreateMap<Comments, CommentsCreateDto>();
            CreateMap<Comments, CommentsUpdateDto>().ReverseMap();
        }
    }
}
