using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(int id);
        Task<Basket> UpdateById(Basket entity, int id);
    }
}
