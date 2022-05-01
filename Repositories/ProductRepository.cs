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

        public Product AddProduct(Product product)
        {
            _dbSet.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product GetProductById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<Product> GetProductsByUser(int userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }

        public Product UpdateProduct(Product product, int id)
        {
            var _product = _dbSet.Find(id);
            if (_product == null)
                return null;
            var response = _context.Entry(_product);
            response.State = EntityState.Modified;

            _context.SaveChanges();
            var result = response.Entity;

            return result;
        }
    }
}
