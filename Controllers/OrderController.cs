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
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public OrderController(IOrderService orderService, IMapper mapper, IMemoryCache cache)
        {
            _orderService = orderService;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetOrdersByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();

            string cacheKey = "orders" + userId;
            List<Order> orders;
            if (!_cache.TryGetValue(cacheKey, out orders))
            {
                orders = await _orderService.GetOrdersByUserId(userId);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, orders, cacheEntryOptions);
            }
            var ordersDto = _mapper.Map<List<Order>, List<OrderReadDto>>(orders);
            return Ok(ordersDto);
        }
    }
}
