using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        public FavouritesController(IFavouritesService favouritesService, IMapper mapper)
        {
            _favouritesService = favouritesService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetFavourites(int id)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var favourites = await _favouritesService.GetFavouritesById(id);
            if (favourites == null)
                return NotFound();
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
            return Ok(favouritesProductDto);

        }
    }
}
