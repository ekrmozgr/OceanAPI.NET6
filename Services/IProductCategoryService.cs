using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategory>> GetProductCategories();
    }
}
