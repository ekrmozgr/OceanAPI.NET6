using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public User AddUser(User user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _dbSet.ToList();
        }

        public User GetUser(int id)
        {
            return _dbSet.Find(id);
        }

        public User UpdateUser(User user, int id)
        {
            var _user = _dbSet.Find(id);
            if (_user == null)
                return null;
            var response = _context.Entry(_user);
            response.State = EntityState.Modified;

            _context.SaveChanges();
            var result = response.Entity;
            
            return result;
        }
    }
}
