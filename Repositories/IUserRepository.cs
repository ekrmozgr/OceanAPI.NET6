using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User AddUser(User user);
        User UpdateUser(User user, int id);
        User GetUser(int id);
    }
}
