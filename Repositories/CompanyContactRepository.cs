using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class CompanyContactRepository : ICompanyContactRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<CompanyContacts> _dbSet;

        public CompanyContactRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<CompanyContacts>();
        }
        public async Task<CompanyContacts> GetCompanyContact()
        {
            return await _dbSet.FirstAsync();
        }
    }
}
