using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            if (!Extensions.IsCurrentUser(id, User))
                return Forbid();
            var user = await _userService.GetUserById(id);
            if(user == null)
                return NotFound();
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
            return Ok(userDto);
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
            var userDto = _mapper.Map<UserReadDto>(user);
            return Ok(userDto);
        }
    }
}
