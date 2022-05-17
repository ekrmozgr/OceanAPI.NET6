using System.ComponentModel.DataAnnotations;
using OceanAPI.NET6.Models;
namespace OceanAPI.NET6.Dtos
{
    public class ProductUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100)]
        public int DiscountPercent { get; set; }

        [Required]
        [StringLength(1500, MinimumLength = 10)]
        public string Explanation { get; set; }

        [Required]
        [Range(typeof(Int32), "0", "500")]
        public string CourseHourDuration { get; set; }

        [Required]
        [Range(typeof(Int32), "0", "59")]
        public string CourseMinuteDuration { get; set; }

        [Required]
        [Range(1, 13)]
        public int ProductCategoryId { get; set; }

        [Required]
        [Range(1, 3)]
        public int CourseLevelId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyWebsite { get; set; }
        [Required]
        public string Base64Image { get; set; }
    }
}
