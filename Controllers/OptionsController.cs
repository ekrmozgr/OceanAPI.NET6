using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/Options")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly IEnumService _enumService;
        private readonly IMapper _mapper;
        public OptionsController(IEnumService enumService, IMapper mapper)
        {
            _enumService = enumService;
            _mapper = mapper;
        }

        [HttpGet("roles")]
        public async Task<ActionResult> GetRoles()
        {
            var roles = await _enumService.GetRoles();
            var rolesDto = _mapper.Map<List<EnumOptionReadDto>>(roles);
            return Ok(rolesDto);
        }

        [HttpGet("courselevels")]
        public async Task<ActionResult> GetCourseLevels()
        {
            var courseLevels = await _enumService.GetCourseLevels();
            var levelsDto = _mapper.Map<List<EnumOptionReadDto>>(courseLevels);
            return Ok(levelsDto);
        }
        [HttpGet("categories")]
        public async Task<ActionResult> GetProductCategories()
        {
            var categories = await _enumService.GetProductCategories();
            var categoriesDto = _mapper.Map<List<EnumOptionReadDto>>(categories);
            return Ok(categoriesDto);
        }
    }
}
