using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface ILoginService
    {
        User Authenticate(UserLoginDto userLogin);
        string GenerateToken(User user);
    }
}
