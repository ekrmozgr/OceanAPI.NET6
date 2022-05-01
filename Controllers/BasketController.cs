using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IBasketTransactionService _basketTransactionService;
        private readonly IMapper _mapper;
        public BasketController(IBasketTransactionService basketTransactionService, IMapper mapper)
        {
            _mapper = mapper;
            _basketTransactionService = basketTransactionService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{basketId}")]
        public async Task<ActionResult> GetBasket(int basketId)
        {
            if (!Extensions.IsCurrentUser(basketId, User))
                return Forbid();
            var basket = await _basketTransactionService.GetBasket(basketId);
            if (basket == null)
                return NotFound();
            var basketDto = _mapper.Map<Basket,BasketDto>(basket);
            return Ok(basketDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("{id}/products")]
        public async Task<ActionResult> AddProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var response = await _basketTransactionService.AddProduct(id, basketProductCreateDto);
            if (response == null)
                return BadRequest();
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}/products")]
        public async Task<ActionResult> ChangeProduct(int id, BasketProductCreateDto basketProductCreateDto)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var response = await _basketTransactionService.ChangeProduct(id, basketProductCreateDto);
            if (response == null)
                return BadRequest();
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
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
            var basketDto = _mapper.Map<Basket, BasketDto>(response);
            return Ok(basketDto);
        }
    }
}
