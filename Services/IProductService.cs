using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IProductService
    {
        Product GetProduct(int id);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByUser(int userId);
        Product UpdateProduct(Product product, int id);
        Product CreateProduct(Product product);
        Product DeleteProduct(int id);
    }
}
