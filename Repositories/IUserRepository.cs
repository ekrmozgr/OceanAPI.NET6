using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user, int id);
        Task<User> GetUser(int id);
    }
}
