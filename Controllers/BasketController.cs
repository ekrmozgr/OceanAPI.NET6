using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketTransactionService _basketTransactionService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public BasketController(IBasketTransactionService basketTransactionService, IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _basketTransactionService = basketTransactionService;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBasket(int id)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var basket = await _basketTransactionService.GetBasket(id);
            if (basket == null)
                return NotFound();
            var basketDto = _mapper.Map<Basket,BasketReadDto>(basket);
            return Ok(basketDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("products")]
        public async Task<ActionResult> AddProduct(BasketProductCreateDto basketProductCreateDto)
        {
            int id = basketProductCreateDto.BasketId;
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var basketProduct = _mapper.Map<BasketProductCreateDto,BasketProduct>(basketProductCreateDto);
            var response = await _basketTransactionService.AddProduct(basketProduct);
            if (response == null)
                return BadRequest();
            return Ok(basketProductCreateDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("products")]
        public async Task<ActionResult> ChangeProductQuantity(BasketProductCreateDto basketProductCreateDto)
        {
            int id = basketProductCreateDto.BasketId;
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var existingBasketProduct = await _basketTransactionService.GetBasketProduct(id, basketProductCreateDto.ProductId);
            if(existingBasketProduct == null)
                return NotFound();
            var basketProduct = _mapper.Map(basketProductCreateDto, existingBasketProduct);
            var response = await _basketTransactionService.ChangeProduct(basketProduct);
            if (response == null)
                return BadRequest();
            return Ok(basketProductCreateDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}/products/{productId}")]
        public async Task<ActionResult> RemoveProduct(int id, int productId)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var response = await _basketTransactionService.RemoveProduct(id, productId);
            if (response == null)
                return BadRequest();
            var basketProductDto = _mapper.Map<BasketProduct, BasketProductCreateDto>(response);
            return Ok(basketProductDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("purchase")]
        public async Task<ActionResult> PurchaseBasket(PurchaseDto purchaseDto)
        {
            if (!Extensions.IsCurrentUser(purchaseDto.BasketId, User))
                return Forbid();
            var basket = await _basketTransactionService.GetBasket(purchaseDto.BasketId);
            if(basket == null)
                return NotFound();
            var response = await _basketTransactionService.PurchaseBasket(basket, purchaseDto);
            if (response == null)
                return BadRequest();
            var orderPurchaseDto = _mapper.Map<Order,OrderPurchaseDto>(response);
            string cacheKey = "orders" + basket.UserId;
            _cache.Remove(cacheKey);
            string cacheKey2 = "coupons" + basket.UserId;
            _cache.Remove(cacheKey2);
            return Ok(orderPurchaseDto);
        }
    }
}
