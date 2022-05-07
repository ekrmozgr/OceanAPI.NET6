using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetOrdersByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();
            var orders = await _orderService.GetOrdersByUserId(userId);
            var ordersDto = _mapper.Map<List<Order>, List<OrderReadDto>>(orders);
            return Ok(ordersDto);
        }
    }
}
