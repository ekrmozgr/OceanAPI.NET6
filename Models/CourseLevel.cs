using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum ECourseLevel
    {
        [Display(Name = "Beginner")]
        BASLANGIC = 1,
        [Display(Name = "Intermediate")]
        ORTA = 2,
        [Display(Name = "Advanced")]
        ILERI = 3
    }
    public class CourseLevel
    {
        [Key]
        public int CourseLevelId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public ECourseLevel ECourseLevel { get; set; }
    }
}
