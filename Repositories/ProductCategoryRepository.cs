using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<ProductCategory> _dbSet;
        public ProductCategoryRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<ProductCategory>();
        }
        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
