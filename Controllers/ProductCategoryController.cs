using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/productcategories")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductCategories()
        {
            var categories = await _productCategoryService.GetProductCategories();
            var categoriesDto = _mapper.Map<List<ProductCategoryReadDto>>(categories);
            return Ok(categoriesDto);
        }
    }
}
