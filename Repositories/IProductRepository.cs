using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        Product UpdateProduct(Product product, int id);
        Product AddProduct(Product product);
        List<Product> GetProductsByUser(int userId);
    }
}
