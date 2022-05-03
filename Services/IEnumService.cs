using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IEnumService
    {
        Task<List<ProductCategory>> GetProductCategories();
        Task<List<CourseLevel>> GetCourseLevels();
        Task<List<Role>> GetRoles();
    }
}
