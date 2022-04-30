using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IBasketService
    {
        Basket GetBasket(int id);
        Basket UpdateById(Basket basket, int id);
    }
}
