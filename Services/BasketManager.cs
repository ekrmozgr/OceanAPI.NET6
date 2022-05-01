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

        public async Task<Basket> GetBasket(int id)
        {
            var basket = await _basketRepository.GetBasket(id);
            if (basket == null)
                return null;
            return basket;
        }

        public async Task<Basket> UpdateById(Basket basket, int id)
        {
            return await _basketRepository.UpdateById(basket, id);
        }
    }
}
