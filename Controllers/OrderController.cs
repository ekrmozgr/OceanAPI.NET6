using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetOrdersByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();
            var orders = await _orderService.GetOrdersByUserId(userId);
            return Ok(orders);
        }
    }
}
