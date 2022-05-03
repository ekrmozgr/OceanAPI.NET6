using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;

namespace OceanAPI.NET6.Repositories
{
    public class EnumRepository<T> : IEnumRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;
        public EnumRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
