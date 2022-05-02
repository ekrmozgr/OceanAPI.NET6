using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/infos")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;
        private readonly IMapper _mapper;

        public InfoController(IInfoService infoService, IMapper mapper)
        {
            _infoService = infoService;
            _mapper = mapper;
        }

        [HttpGet("faq")]
        public async Task<ActionResult> GetFaqs()
        {
            var faqs = await _infoService.GetFaqs();
            var faqsDto = _mapper.Map<List<FaqReadDto>>(faqs);
            return Ok(faqsDto);
        }
        [HttpGet("company")]
        public async Task<ActionResult> GetCompanyContacts()
        {
            return Ok(await _infoService.GetCompanyContacts());
        }
    }
}
