using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IBasketRepository
    {
        Basket GetBasket(int id);
        Basket UpdateById(Basket entity, int id);
    }
}
