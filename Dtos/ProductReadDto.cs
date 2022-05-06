using OceanAPI.NET6.Models;
using System.Runtime.Serialization;

namespace OceanAPI.NET6.Dtos
{
    public class ProductReadDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Explanation { get; set; }
        public string CourseHourDuration { get; set; }
        public string CourseMinuteDuration { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CourseLevelId { get; set; }
        public string CourseLevel { get; set; }
        public UserInProductReadDto User { get; set; }
    }
}
