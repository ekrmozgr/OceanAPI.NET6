using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<Product> UpdateProduct(Product product, int id);
        Task<Product> AddProduct(Product product);
        Task<List<Product>> GetProductsByUser(int userId);
    }
}
