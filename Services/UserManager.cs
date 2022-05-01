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
        public async Task<User> CreateUser(User user)
        {
            var existingUser = (await _userRepository.GetAllUsers()).SingleOrDefault(u=> u.Email.Equals(user.Email) || u.MobilePhone.Equals(user.MobilePhone));
            if (existingUser != null)
                return null;
            return await _userRepository.AddUser(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            return await _userRepository.UpdateUser(user, id);
        }
    }
}
