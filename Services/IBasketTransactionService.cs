using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IBasketTransactionService
    {
        Task<Basket> GetBasket(int id);
        Task<Basket> AddProduct(int id, BasketProductCreateDto basketProductCreateDto);
        Task<Basket> ChangeProduct(int id, BasketProductCreateDto basketProductCreateDto);

        Task<Basket> RemoveProduct(int id, int productId);
    }
}
