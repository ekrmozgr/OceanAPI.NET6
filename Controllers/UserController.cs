using AutoMapper;
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

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if(user == null)
                return NotFound();
            var userDto = _mapper.Map<User, UserReadDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult CreateUser(UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<UserCreateDto, User>(userCreateDto);
            var response = _userService.CreateUser(user);
            var userDto = _mapper.Map<User,UserReadDto>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserCreateDto createUserDto)
        {
            var existingUser = _userService.GetUserById(id);
            if (existingUser == null)
                return NotFound();
            var user = _mapper.Map(createUserDto, existingUser);
            _userService.UpdateUser(user, id);
            var userDto = _mapper.Map<UserReadDto>(user);
            return Ok(userDto);
        }
    }
}
