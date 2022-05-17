using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProductsByCategory(int categoryId);
        Task<List<Product>> GetProductsByUser(int userId);
        Task<Product> UpdateProduct(Product product, int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> RemoveProduct(int id);
    }
}
