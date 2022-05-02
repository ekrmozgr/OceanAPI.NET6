using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class FAQ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FAQId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public int FAQCategoryId { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public EFAQCategory FaqCategory { get; set; }
    }
}
