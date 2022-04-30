using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IBasketTransactionService _basketTransactionService;
        private readonly IMapper _mapper;
        public BasketController(IBasketService basketService, IBasketTransactionService basketTransactionService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
            _basketTransactionService = basketTransactionService;
        }

        [HttpGet("{basketId}")]
        public ActionResult GetBasket(int basketId)
        {
            var basket = _basketService.GetBasket(basketId);
            if (basket == null)
                return NotFound();
            var basketDto = _mapper.Map<Basket,BasketDto>(basket);
            return Ok(basketDto);
        }

        [HttpPost("{id}/products")]
        public ActionResult AddProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            var response = _basketTransactionService.AddProduct(id, basketProductCreateDto);
            if (response == null)
                return BadRequest();
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
        }
        [HttpPut("{id}/products")]
        public ActionResult ChangeProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            var response = _basketTransactionService.ChangeProduct(id, basketProductCreateDto);
            if (response == null)
                return BadRequest();
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
        }
        [HttpDelete("{id}/products/{productId}")]
        public ActionResult RemoveProduct(int id, int productId)
        {
            var response = _basketTransactionService.RemoveProduct(id, productId);
            if (response == null)
                return BadRequest();
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
        }
    }
}
