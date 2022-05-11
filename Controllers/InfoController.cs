using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/infos")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public InfoController(IInfoService infoService, IMapper mapper, IMemoryCache cache)
        {
            _infoService = infoService;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet("faq")]
        public async Task<ActionResult> GetFaqs()
        {

            string cacheKey = "faqs";
            List<FAQCategory> faqs;
            if (!_cache.TryGetValue(cacheKey, out faqs))
            {
                faqs = await _infoService.GetFaqs();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, faqs, cacheEntryOptions);
            }
            var faqsDto = _mapper.Map<List<FaqReadDto>>(faqs);
            return Ok(faqsDto);
        }
        [HttpGet("company")]
        public async Task<ActionResult> GetCompanyContacts()
        {
            string cacheKey = "companycontact";
            CompanyContacts companyContacts;
            if (!_cache.TryGetValue(cacheKey, out companyContacts))
            {
                companyContacts = await _infoService.GetCompanyContacts();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30))
                    .SetPriority(CacheItemPriority.Low);
                _cache.Set(cacheKey, companyContacts, cacheEntryOptions);
            }
            if (companyContacts == null)
                return NotFound();
            return Ok(companyContacts);
        }
    }
}
