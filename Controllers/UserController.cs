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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public UserController(IUserService userService, IMapper mapper, IMemoryCache cache)
        {
            _userService = userService;
            _mapper = mapper;
            _cache = cache;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            string cacheKey = "user" + id;
            User user;
            if (!_cache.TryGetValue(cacheKey, out user))
            {
                user = await _userService.GetUserById(id);
                if (user == null)
                    return NotFound();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(20))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set(cacheKey, user, cacheEntryOptions);
            }
            var userDto = _mapper.Map<User, UserReadDto>(user);
            return Ok(userDto);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<UserCreateDto, User>(userCreateDto);
            var response = await _userService.CreateUser(user);
            if(response == null)
                return BadRequest();
            var userDto = _mapper.Map<User,UserReadDto>(user);
            return Created(nameof(GetUser), userDto);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserCreateDto createUserDto)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
                return NotFound();
            var user = _mapper.Map(createUserDto, existingUser);
            await _userService.UpdateUser(user, id);
            string cacheKey = "user" + id;
            _cache.Remove(cacheKey);
            var userDto = _mapper.Map<UserReadDto>(user);
            return Ok(userDto);
        }
    }
}
