using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/Options")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IEnumService _enumService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public OptionsController(IEnumService enumService, IMapper mapper, IMemoryCache cache)
        {
            _enumService = enumService;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet("roles")]
        public async Task<ActionResult> GetRoles()
        {
            string cacheKey = "roles";
            List<Role> roles;
            if (!_cache.TryGetValue(cacheKey, out roles))
            {
                roles = await _enumService.GetRoles();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(20))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, roles, cacheEntryOptions);
            }
            var rolesDto = _mapper.Map<List<EnumOptionReadDto>>(roles);
            return Ok(rolesDto);
        }

        [HttpGet("courselevels")]
        public async Task<ActionResult> GetCourseLevels()
        {
            string cacheKey = "levels";
            List<CourseLevel> courseLevels;
            if (!_cache.TryGetValue(cacheKey, out courseLevels))
            {
                courseLevels = await _enumService.GetCourseLevels();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(20))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, courseLevels, cacheEntryOptions);
            }
            var levelsDto = _mapper.Map<List<EnumOptionReadDto>>(courseLevels);
            return Ok(levelsDto);
        }
        [HttpGet("categories")]
        public async Task<ActionResult> GetProductCategories()
        {

            string cacheKey = "categories";
            List<ProductCategory> categories;
            if (!_cache.TryGetValue(cacheKey, out categories))
            {
                categories = await _enumService.GetProductCategories();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.NeverRemove);
                _cache.Set(cacheKey, categories, cacheEntryOptions);
            }
            var categoriesDto = _mapper.Map<List<EnumOptionReadDto>>(categories);
            return Ok(categoriesDto);
        }
    }
}
