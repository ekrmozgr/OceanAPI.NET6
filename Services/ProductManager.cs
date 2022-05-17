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

        public async Task<Product> CreateProduct(Product product)
        {
            decimal discount = product.Price * product.DiscountPercent / 100;
            product.DiscountPrice = product.Price - discount;
            return await _productRepository.AddProduct(product);
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _productRepository.GetProductsByCategory(categoryId);
        }

        public async Task<List<Product>> GetProductsByUser(int userId)
        {
            return await _productRepository.GetProductsByUser(userId);
        }

        public async Task<Product> RemoveProduct(int id)
        {
            var product = await _productRepository.GetProductForRemove(id);
            if(product == null)
                return null;
            if (product.isAvailable == false)
                return null;
            product.isAvailable = false;
            product.BasketProducts.Clear();
            product.FavouritesProducts.Clear();
            return await _productRepository.UpdateProduct(product, id);
        }

        public async Task<Product> UpdateProduct(Product product, int id)
        {
            decimal discount = product.Price * product.DiscountPercent / 100;
            product.DiscountPrice = product.Price - discount;
            return await _productRepository.UpdateProduct(product, id);
        }
    }
}
