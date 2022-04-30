using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        public BasketManager(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Basket GetBasket(int id)
        {
            var basket = _basketRepository.GetBasket(id);
            if (basket == null)
                return null;
            return basket;
        }

        public Basket UpdateById(Basket basket, int id)
        {
            return _basketRepository.UpdateById(basket, id);
        }
    }
}
