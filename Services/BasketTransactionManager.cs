using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public class BasketTransactionManager : IBasketTransactionService
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public BasketTransactionManager(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public Basket AddProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            // product baskette var mi kontrol
            if (basketProductCreateDto.ProductQuantity <= 0)
                return null;
            var basket = _basketService.GetBasket(id);
            if (basket == null)
                return null;
            var product = _productService.GetProduct(basketProductCreateDto.ProductId);
            if (product == null)
                return null;
            basket.BasketProducts.Add(new BasketProduct { ProductId = basketProductCreateDto.ProductId, BasketId = id, ProductQuantity = basketProductCreateDto.ProductQuantity });
            basket.ProductCount++;
            basket.Price += basketProductCreateDto.ProductQuantity * product.DiscountPrice;
            return _basketService.UpdateById(basket, id);
        }
    }
}
