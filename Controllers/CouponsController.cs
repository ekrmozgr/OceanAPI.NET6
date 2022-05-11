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
    [Route("api/coupons")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public CouponsController(ICouponService couponService, IMapper mapper, IMemoryCache cache)
        {
            _couponService = couponService;
            _mapper = mapper;
            _cache = cache;

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetCouponsByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();

            string cacheKey = "coupons" + userId;
            List<Coupon> coupons;
            if (!_cache.TryGetValue(cacheKey, out coupons))
            {
                coupons = await _couponService.GetCouponsByUser(userId);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, coupons, cacheEntryOptions);
            }
            return Ok(coupons);
        }
    }
}
