using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Services;

namespace OceanAPI.NET6.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginDto userLogin)
        {
            var user = await _loginService.Authenticate(userLogin);
            if(user == null)
                return NotFound();

            var token = _loginService.GenerateToken(user);
            return Ok(token);
        }
    }
}
