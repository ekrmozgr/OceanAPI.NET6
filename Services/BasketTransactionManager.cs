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
            if (basketProductCreateDto.ProductQuantity <= 0)
                return null;
            var basket = _basketService.GetBasket(id);
            if (basket == null)
                return null;
            var product = _productService.GetProduct(basketProductCreateDto.ProductId);
            if (product == null)
                return null;
            if(basket.BasketProducts.FirstOrDefault(b => b.ProductId.Equals(basketProductCreateDto.ProductId)) != null)
            {
                return basket;
            }
            basket.BasketProducts.Add(new BasketProduct { ProductId = basketProductCreateDto.ProductId, BasketId = id, ProductQuantity = basketProductCreateDto.ProductQuantity });
            basket.ProductCount++;
            basket.Price += basketProductCreateDto.ProductQuantity * product.DiscountPrice;
            return _basketService.UpdateById(basket, id);
        }

        public Basket ChangeProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            if (basketProductCreateDto.ProductQuantity <= 0)
                return null;
            var basket = _basketService.GetBasket(id);
            if (basket == null)
                return null;
            var product = _productService.GetProduct(basketProductCreateDto.ProductId);
            if (product == null)
                return null;
            var basketProduct = basket.BasketProducts.FirstOrDefault(bp => bp.ProductId.Equals(product.ProductId));
            if (basketProduct == null)
                return null;

            basket.Price -= basketProduct.ProductQuantity * product.DiscountPrice;
            basket.BasketProducts.FirstOrDefault(bp => bp.ProductId.Equals(product.ProductId)).ProductQuantity = basketProductCreateDto.ProductQuantity;
            basket.Price += basketProductCreateDto.ProductQuantity * product.DiscountPrice;

            return _basketService.UpdateById(basket, id);
        }

        public Basket RemoveProduct(int id, int productId)
        {
            var basket = _basketService.GetBasket(id);
            if (basket == null)
                return null;
            var product = _productService.GetProduct(id);
            if (product == null)
                return null;
            var basketProduct = basket.BasketProducts.FirstOrDefault(b => b.ProductId.Equals(productId));
            if (basketProduct == null)
                return null;
            basket.BasketProducts.Remove(basketProduct);

            basket.ProductCount -= 1;
            basket.Price -= basketProduct.ProductQuantity * product.DiscountPrice;

            return _basketService.UpdateById(basket, id);
        }
    }
}
