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

        public async Task<Product> AddProduct(Product product)
        {
            await _dbSet.AddAsync(product);
            await _context.SaveChangesAsync();
            await _context.Entry(product).Reference(p => p.User).LoadAsync();
            return product;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _dbSet.Include(x => x.User).Include(x=>x.Comments).ThenInclude(c=>c.User).FirstOrDefaultAsync(x=> x.ProductId.Equals(id));
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _dbSet.Where(x => x.ProductCategoryId.Equals(categoryId)).Include(x=> x.User).Include(x => x.Comments).ThenInclude(c => c.User).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByUser(int userId)
        {
            return await _dbSet.Where(x => x.UserId.Equals(userId)).Include(x => x.User).Include(x => x.Comments).ThenInclude(c => c.User).ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product, int id)
        {
            var _product = await _dbSet.FindAsync(id);
            if (_product == null)
                return null;
            var response = _context.Entry(_product);
            response.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            var result = response.Entity;

            return result;
        }
    }
}
