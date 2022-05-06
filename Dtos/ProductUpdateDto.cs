using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class ProductUpdateDto
    {
        [Required]
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
        //[RegularExpression("0 | ^[1-9][0-9]*$")]
        public string CourseHourDuration { get; set; }

        [Required]
        //[RegularExpression("0 | ^[1-9][0-9]*$")]
        public string CourseMinuteDuration { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        public int CourseLevelId { get; set; }
    }
}
