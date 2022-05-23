using AutoMapper;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<Basket, BasketReadDto>();
            CreateMap<BasketProduct, BasketProductReadDto>();
            CreateMap<Product, ProductReadDto>()
                .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.ProductCategory.GetDisplayName()))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(a => a.CourseLevel.GetDisplayName()))
                .ForMember(p => p.Base64Image, x => x.MapFrom(a => Convert.ToBase64String(a.Image)));
            CreateMap<User, UserInProductReadDto>();
            CreateMap<BasketProductCreateDto, BasketProduct>().ReverseMap();
            CreateMap<Order, OrderPurchaseDto>();
            CreateMap<FAQCategory, FaqReadDto>()
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
            CreateMap<FavouritesCreateDto, FavouritesProduct>().ReverseMap();
            CreateMap<Favourites, FavouritesReadDto>();
            CreateMap<FavouritesProduct, FavouritesProductReadDto>();
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(p => p.ProductCategory, x => x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(pu => (ECourseLevel)pu.CourseLevelId))
                .ForMember(p => p.Image, x => x.MapFrom(pu => Convert.FromBase64String(pu.Base64Image)));
            CreateMap<ProductCreateDto, Product>()
                .ForMember(p => p.ProductCategory, x => x.MapFrom(pu => (EProductCategory)pu.ProductCategoryId))
                .ForMember(p => p.CourseLevel, x => x.MapFrom(pu => (ECourseLevel)pu.CourseLevelId))
                .ForMember(p => p.Image, x => x.MapFrom(pu => Convert.FromBase64String(pu.Base64Image)));
            CreateMap<Product, ProductCreateDto>()
                .ForMember(p => p.Base64Image, x => x.MapFrom(a => Convert.ToBase64String(a.Image)));
            CreateMap<Comments, CommentsReadDto>()
                .ForMember(O => O.DateOfComment, x => x.MapFrom(a => a.DateOfComment.ToString()));
            CreateMap<CommentsCreateDto, Comments>();
            CreateMap<Comments, CommentsCreateDto>();
            CreateMap<Comments, CommentsUpdateDto>().ReverseMap();
            CreateMap<Order, OrderReadDto>()
                .ForMember(O => O.DateOfOrder, x => x.MapFrom(a => a.DateOfOrder.ToString()));
            CreateMap<OrderProduct, OrderProductReadDto>();
            CreateMap<Coupon, CouponReadDto>();
        }
    }
}
