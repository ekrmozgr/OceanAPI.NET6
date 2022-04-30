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

        public List<User> GetAllUsers()
        {
            return _dbSet.ToList();
        }
    }
}
