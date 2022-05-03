using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum ECourseLevel
    {
        [Display(Name = "Başlangıç")]
        BASLANGIC = 1,
        [Display(Name = "Orta")]
        ORTA = 2,
        [Display(Name = "İleri")]
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
