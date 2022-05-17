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
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;


        public ProductController(IProductService productService, IMapper mapper, IMemoryCache cache)
        {
            _productService = productService;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            string cacheKey = "product" + id;
            Product product;
            if (!_cache.TryGetValue(cacheKey, out product))
            {
                product = await _productService.GetProduct(id);
                if (product == null)
                    return NotFound();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(15))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set(cacheKey, product, cacheEntryOptions);
            }
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles="INSTRUCTOR,ADMIN")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductCreateDto productCreateDto)
        {
            if (!Extensions.IsCurrentUser(productCreateDto.UserId, User) && !User.IsInRole("ADMIN"))
                return Forbid();
            var product = _mapper.Map<Product>(productCreateDto);
            var response = await _productService.CreateProduct(product);
            var productDto = _mapper.Map<ProductReadDto>(response);
            string cacheKey = "instructorProducts" + product.UserId;
            _cache.Remove(cacheKey);
            return Created(nameof(GetProduct), productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult> GetProductsByCategory(int categoryId)
        {
            string cacheKey = "categoryProducts" + categoryId;
            List<Product> products;
            if (!_cache.TryGetValue(cacheKey, out products))
            {
                products = await _productService.GetProductsByCategory(categoryId);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.High);
                _cache.Set(cacheKey, products, cacheEntryOptions);
            }
            var productsDto = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(productsDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetProductsByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();
            string cacheKey = "instructorProducts" + userId;
            List<Product> products;
            if (!_cache.TryGetValue(cacheKey, out products))
            {
                products = await _productService.GetProductsByUser(userId);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.High);
                _cache.Set(cacheKey, products, cacheEntryOptions);
            }
            var productDto = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "INSTRUCTOR,ADMIN")]
        [HttpPut]
        public async Task<ActionResult> EditProduct(ProductUpdateDto productUpdateDto)
        {
            var existingProduct = await _productService.GetProduct(productUpdateDto.ProductId);
            if (existingProduct == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(existingProduct.UserId, User) && !User.IsInRole("ADMIN"))
                return Forbid();
            if (!existingProduct.isAvailable)
                return BadRequest();
            var product = _mapper.Map(productUpdateDto,existingProduct);
            await _productService.UpdateProduct(product, productUpdateDto.ProductId);
            string cacheKey = "product" + product.ProductId;
            _cache.Remove(cacheKey);
            string cacheKey2 = "instructorProducts" + product.UserId;
            _cache.Remove(cacheKey2);
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }

        [HttpPut("remove/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "INSTRUCTOR,ADMIN")]
        public async Task<ActionResult> RemoveProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(product.UserId, User) && !User.IsInRole("ADMIN"))
                return Forbid();
            var response = await _productService.RemoveProduct(id);
            if (response == null)
                return BadRequest();
            string cacheKey = "product" + product.ProductId;
            _cache.Remove(cacheKey);
            string cacheKey2 = "instructorProducts" + product.UserId;
            _cache.Remove(cacheKey2);
            return Ok(id);
        }
    }
}
