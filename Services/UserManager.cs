using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        // user var mi yok mu kontrol et
        public User CreateUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUser(id);
        }

        public User UpdateUser(User user, int id)
        {
            return _userRepository.UpdateUser(user, id);
        }
    }
}
