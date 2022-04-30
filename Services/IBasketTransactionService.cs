using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IBasketTransactionService
    {
        Basket AddProduct(int id, BasketProductCreateDto basketProductCreateDto);
        Basket ChangeProduct(int id, BasketProductCreateDto basketProductCreateDto);

        Basket RemoveProduct(int id, int productId);
    }
}
