using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class EnumManager : IEnumService
    {

        private readonly IEnumRepository<Role> _roleRepository;
        private readonly IEnumRepository<CourseLevel> _courseLevelRepository;
        private readonly IEnumRepository<ProductCategory> _productCategoryRepository;
        public EnumManager(IEnumRepository<Role> roleRepository, IEnumRepository<CourseLevel> courseLevelRepository, IEnumRepository<ProductCategory> productCategoryRepository)
        {
            _roleRepository = roleRepository;
            _courseLevelRepository = courseLevelRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<CourseLevel>> GetCourseLevels()
        {
            return await _courseLevelRepository.Get();
        }

        public async Task<List<ProductCategory>> GetProductCategories()
        {
            return await _productCategoryRepository.Get();
        }

        public async Task<List<Role>> GetRoles()
        {
            return await _roleRepository.Get();
        }
    }
}
