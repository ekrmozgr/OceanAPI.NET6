using Microsoft.IdentityModel.Tokens;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OceanAPI.NET6.Services
{
    public class LoginManager : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public LoginManager(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }
        public async Task<User> Authenticate(UserLoginDto userLogin)
        {
            User? user = (await _userRepository.GetAllUsers()).FirstOrDefault(u => u.Email.ToLower() == userLogin.Email.ToLower() &&
                                                                     u.Password == userLogin.Password);
            return user;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                notBefore: DateTime.Now,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
