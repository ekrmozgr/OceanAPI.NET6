using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IBasketTransactionService
    {
        Task<Basket> GetBasket(int id);
        Task<Basket> AddProduct(BasketProduct basketProduct);
        Task<Basket> ChangeProduct(BasketProduct basketProduct);

        Task<BasketProduct> RemoveProduct(int id, int productId);
        Task<Order> PurchaseBasket(Basket basket, PurchaseDto purchaseDto);

        Task<BasketProduct> GetBasketProduct(int basketId, int productId);
    }
}
