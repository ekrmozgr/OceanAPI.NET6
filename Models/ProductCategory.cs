using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum EProductCategory
    {
        [Display(Name = "Cloud")]
        BULUT = 1,
        [Display(Name = "DevOps")]
        DEVOPS = 2,
        [Display(Name = "ERP")]
        ERP = 3,
        [Display(Name = "Game Design Development")]
        OYUN_TASARIMI_GELISTIRME = 4,
        [Display(Name = "Network Tehcnologies")]
        AG_TEKNOLOJILERI = 5,
        [Display(Name = "Cyber Security")]
        SIBER_GUVENLIK = 6,
        [Display(Name = "UI/UX Design")]
        UI_UX_TASARIMI = 7,
        [Display(Name = "Data Science")]
        VERI_BILIMI = 8,
        [Display(Name = "Backend Developer")]
        BACK_END_DEVELOPER = 9,
        [Display(Name = "Frontend Developer")]
        FRONT_END_DEVELOPER = 10,
        [Display(Name = "Fullstack Developer")]
        FULL_STACK_DEVELOPER = 11,
        [Display(Name = "Game Developer")]
        GAME_DEVELOPER = 12,
        [Display(Name = "Mobile Developer")]
        MOBILE_DEVELOPER = 13
    }
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public EProductCategory ProductCategorys { get; set; }
    }
}
