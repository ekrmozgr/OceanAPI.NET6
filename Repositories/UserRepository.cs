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

        public async Task<User> AddUser(User user)
        {
            await _dbSet.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<User> UpdateUser(User user, int id)
        {
            var _user = await _dbSet.FindAsync(id);
            if (_user == null)
                return null;
            var response = _context.Entry(_user);
            response.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            var result = response.Entity;
            
            return result;
        }
    }
}
