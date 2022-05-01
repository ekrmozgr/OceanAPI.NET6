using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user, int id);
        Task<User> GetUserById(int id);
    }
}
