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
    [Route("api/favourites")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesService _favouritesService;
        private IMemoryCache _cache;
        private readonly IMapper _mapper;
        public FavouritesController(IFavouritesService favouritesService, IMapper mapper, IMemoryCache cache)
        {
            _favouritesService = favouritesService;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetFavourites(int id)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();

            string cacheKey = "favourites" + id;
            Favourites favourites;
            if (!_cache.TryGetValue(cacheKey, out favourites))
            {
                favourites = await _favouritesService.GetFavouritesById(id);
                if (favourites == null)
                    return NotFound();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set(cacheKey, favourites, cacheEntryOptions);
            }
            var favouritesDto = _mapper.Map<Favourites,FavouritesReadDto>(favourites);
            return Ok(favouritesDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("products")]
        public async Task<ActionResult> AddProduct(FavouritesCreateDto favouritesCreateDto)
        {
            if (!Extensions.IsCurrentUser(favouritesCreateDto.FavouritesId, User))
                return Forbid();
            var favouritesProduct = _mapper.Map<FavouritesCreateDto, FavouritesProduct>(favouritesCreateDto);
            var favourites = await _favouritesService.AddProduct(favouritesProduct);
            if (favourites == null)
                return BadRequest();
            string cacheKey = "favourites" + favourites.UserId;
            _cache.Remove(cacheKey);
            return Ok(favouritesCreateDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}/products/{productId}")]
        public async Task<ActionResult> RemoveProduct(int id, int productId)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var favouritesProduct = await _favouritesService.RemoveProduct(id, productId);
            if (favouritesProduct == null)
                return BadRequest();
            var favouritesProductDto = _mapper.Map<FavouritesProduct, FavouritesCreateDto>(favouritesProduct);
            string cacheKey = "favourites" + id;
            _cache.Remove(cacheKey);
            return Ok(favouritesProductDto);

        }
    }
}
