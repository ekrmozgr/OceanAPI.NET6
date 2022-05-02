using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class ProductCategoryManager : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryManager(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await _productCategoryRepository.GetProductCategories();
        }
    }
}
