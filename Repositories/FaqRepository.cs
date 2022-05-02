using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<FAQCategory> _dbSet;

        public FaqRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<FAQCategory>();
        }
        public async Task<List<FAQCategory>> GetFaqs()
        {
            return await _dbSet.Include(fc => fc.faqs).ToListAsync();
        }
    }
}
