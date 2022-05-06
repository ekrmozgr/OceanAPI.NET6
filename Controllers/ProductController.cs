using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if(product == null)
                return NotFound();
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductCreateDto productCreateDto)
        {
            if (!Extensions.IsCurrentUser(productCreateDto.UserId, User))
                return Forbid();
            var product = _mapper.Map<Product>(productCreateDto);
            var response = await _productService.CreateProduct(product);
            var productDto = _mapper.Map<ProductReadDto>(response);
            return Created(nameof(GetProduct), productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult> GetProductsByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategory(categoryId);
            var productsDto = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(productsDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetProductsByUser(int userId)
        {
            if (!Extensions.IsCurrentUser(userId, User))
                return Forbid();
            var products = await _productService.GetProductsByUser(userId);
            var productDto = _mapper.Map<List<ProductReadDto>>(products);
            return Ok(productDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult> EditProduct(ProductUpdateDto productUpdateDto)
        {
            var existingProduct = await _productService.GetProduct(productUpdateDto.ProductId);
            if (existingProduct == null)
                return NotFound();
            if (!Extensions.IsCurrentUser(existingProduct.UserId, User))
                return Forbid();
            var product = _mapper.Map(productUpdateDto,existingProduct);
            await _productService.UpdateProduct(product, productUpdateDto.ProductId);
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }
     }
}
