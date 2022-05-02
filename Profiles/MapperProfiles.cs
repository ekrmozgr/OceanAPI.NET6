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
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.ProductCategory.GetDisplayName()));
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(p => p.ProductCategory, x=> x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId));
            CreateMap<ProductCreateDto, Product>()
                .ForMember(p => p.ProductCategory, x => x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId));

            CreateMap<FAQCategory,FaqReadDto>()
                .ForMember(fr => fr.FaqCategoryName, fc => fc.MapFrom(f => f.FaqCategory.GetDisplayName()));

            CreateMap<ProductCategory, ProductCategoryReadDto>()
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.ProductCategorys.GetDisplayName()));
        }
    }
}
