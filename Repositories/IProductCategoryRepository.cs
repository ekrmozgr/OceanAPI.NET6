using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetProductCategories();
    }
}
