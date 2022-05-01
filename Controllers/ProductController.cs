using AutoMapper;
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

        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _productService.GetProduct(id);
            if(product == null)
                return NotFound();
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            var response = _productService.CreateProduct(product);
            var productDto = _mapper.Map<ProductReadDto>(response);
            return Ok(productDto);
        }

        [HttpDelete("{id}YYYYYYYYY")]
        public ActionResult DeleteProduct()
        {
            return null;
        }

        [HttpGet("category/{categoryId}YYYYYYYYYYY")]
        public ActionResult GetProductsByCategory(int categoryId)
        {
            return Ok(_productService.GetProductsByCategory(categoryId));
        }

        [HttpGet("user/{userId}")]
        public ActionResult GetProductsByUser(int userId)
        {
            var product = _productService.GetProductsByUser(userId);
            var productDto = _mapper.Map<List<ProductReadDto>>(product);
            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public ActionResult EditProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var existingProduct = _productService.GetProduct(id);
            if (existingProduct == null)
                return NotFound();
            if (!existingProduct.UserId.Equals(productUpdateDto.UserId))
                return BadRequest();
            var product = _mapper.Map(productUpdateDto,existingProduct);
            _productService.UpdateProduct(product, id);
            var productDto = _mapper.Map<ProductReadDto>(product);
            return Ok(productDto);
        }
     }
}
