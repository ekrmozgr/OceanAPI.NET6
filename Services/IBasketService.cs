using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(int id);
        Task<Basket> UpdateById(Basket basket, int id);
    }
}
