using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IUserService
    {
        User CreateUser(User user);
        User UpdateUser(User user, int id);
        User GetUserById(int id);
    }
}
