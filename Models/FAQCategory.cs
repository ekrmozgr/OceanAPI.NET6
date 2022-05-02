using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum EFAQCategory
    {
        [Display(Name = "About Our Online Courses")]
        ABOUT_OUR_ONLINE_COURSES = 1,
        [Display(Name = "Enrolment Process")]
        ENROLMENT_PROCESS = 2,
        [Display(Name = "Account Access")]
        ACCOUNT_ACCESS = 3,
        [Display(Name = "Payment")]
        PAYMENT = 4,
        [Display(Name = "Community Support")]
        COMMUNITY_SUPPORT = 5,
        [Display(Name = "Other")]
        OTHER = 6
    }
    public class FAQCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FAQCategoryId { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public EFAQCategory FaqCategory { get; set; }

        public List<FAQ> faqs { get; set; }
    }
}
