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

            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
