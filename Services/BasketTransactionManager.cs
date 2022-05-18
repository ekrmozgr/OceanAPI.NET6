using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public class BasketTransactionManager : IBasketTransactionService
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;
        private readonly IOrderService _orderService;
        public BasketTransactionManager(IBasketService basketService, IProductService productService, ICouponService couponService, IOrderService orderService)
        {
            _basketService = basketService;
            _productService = productService;
            _couponService = couponService;
            _orderService = orderService;
        }

        public async Task<Basket> AddProduct(BasketProduct basketProduct)
        {
            var basket = await _basketService.GetBasket(basketProduct.BasketId);
            if (basket == null)
                return null;
            var product = await _productService.GetProduct(basketProduct.ProductId);
            if (product == null)
                return null;
            if(!product.isAvailable)
                return null;
            if(basket.BasketProducts.FirstOrDefault(b => b.ProductId.Equals(basketProduct.ProductId)) != null)
                return null;
            basket.BasketProducts.Add(basketProduct);
            return await _basketService.UpdateById(basket, basketProduct.BasketId);
        }

        public async Task<Basket> ChangeProduct(BasketProduct basketProduct)
        {
            var basket = await _basketService.GetBasket(basketProduct.BasketId);
            if (basket == null)
                return null;
            var product = await _productService.GetProduct(basketProduct.ProductId);
            if (product == null)
                return null;
            if (basket.BasketProducts.FirstOrDefault(b => b.ProductId.Equals(basketProduct.ProductId)) == null)
                return null;
            return await _basketService.UpdateById(basket, basketProduct.BasketId);
        }

        public async Task<Basket> GetBasket(int id)
        {
            var basket = await _basketService.GetBasket(id);
            if (basket == null)
                return null;
            basket.ProductCount = 0;
            basket.Price = 0;
            foreach (var basketProduct in basket.BasketProducts)
            {
                basket.ProductCount += 1;
                basket.Price += basketProduct.ProductQuantity * basketProduct.Product.DiscountPrice;
            }
            return await _basketService.UpdateById(basket, id);
        }

        public async Task<BasketProduct> RemoveProduct(int id, int productId)
        {
            var basket = await _basketService.GetBasket(id);
            if (basket == null)
                return null;
            var product = await _productService.GetProduct(productId);
            if (product == null)
                return null;
            var basketProduct = basket.BasketProducts.FirstOrDefault(b => b.ProductId.Equals(productId));
            if (basketProduct == null)
                return null;
            basket.BasketProducts.Remove(basketProduct);
            await _basketService.UpdateById(basket, id);
            return basketProduct;
        }

        public async Task<Order> PurchaseBasket(Basket basket, PurchaseDto purchaseDto)
        {
            if (basket.BasketProducts.Count() == 0)
                return null;
            var order = new Order();
            order.Price = basket.Price;
            order.UserId = basket.UserId;
            order.RecipientMail = purchaseDto.Email;
            order.OrderProducts = new List<OrderProduct>();
            order.Coupons = new List<Coupon>();
            string messageBody = order.DateOfOrder.ToLongDateString();
            messageBody+= "\n\nCoupons :\n\n";
            foreach (var basketProduct in basket.BasketProducts)
            {
                int productId = basketProduct.ProductId;
                messageBody += basketProduct.Product.CompanyName + "\n" + basketProduct.Product.CompanyWebsite + "\n\n";
                messageBody += basketProduct.Product.Name + "\n\n";
                order.OrderProducts.Add(new OrderProduct { ProductId = productId, ProductQuantity = basketProduct.ProductQuantity, ProductPrice = basketProduct.Product.DiscountPrice });
                for(int i = 0; i < basketProduct.ProductQuantity; i++)
                {
                    var coupon = new Coupon { ProductId = productId, UserId = basket.UserId, CouponCode = _couponService.GenerateCoupon() };
                    order.Coupons.Add(coupon);
                    messageBody += coupon.CouponCode + "\n";
                }
                messageBody += "\n\n";
            }
            basket.Price = 0;
            basket.ProductCount = 0;
            basket.BasketProducts.Clear();
            await _basketService.UpdateById(basket, basket.UserId);
            await Extensions.Email("Ocean App Courses Coupons", messageBody, purchaseDto.Email);
            return await _orderService.AddOrder(order);
        }

        public async Task<BasketProduct> GetBasketProduct(int basketId, int productId)
        {
            var basket = await _basketService.GetBasket(basketId);
            var basketProduct = basket.BasketProducts.Where(x => x.ProductId.Equals(productId)).FirstOrDefault();
            return basketProduct;
        }
    }
}
