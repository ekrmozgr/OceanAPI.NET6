using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
