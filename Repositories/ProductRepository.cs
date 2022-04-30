using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }
        public Product GetProductById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
