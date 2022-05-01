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

        public Product CreateProduct(Product product)
        {
            // kontrol yap

            decimal discount = product.Price * product.DiscountPercent / 100;
            product.DiscountPrice = product.Price - discount;
            return _productRepository.AddProduct(product);
        }

        public Product DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByUser(int userId)
        {
            return _productRepository.GetProductsByUser(userId);
        }

        public Product UpdateProduct(Product product, int id)
        {
            decimal discount = product.Price * product.DiscountPercent / 100;
            product.DiscountPrice = product.Price - discount;
            return _productRepository.UpdateProduct(product, id);
        }
    }
}
