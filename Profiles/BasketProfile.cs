using AutoMapper;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {

            CreateMap<Basket, BasketDto>();
            CreateMap<BasketProduct, BasketProductReadDto>();
            CreateMap<Product, ProductDto>();
                
        }
    }
}
