using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class Product
    {
        public Product()
        {
            isAvailable = true;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Explanation { get; set; }
        public string CourseHourDuration { get; set; }
        public string CourseMinuteDuration { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }

        public int ProductCategoryId { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public EProductCategory ProductCategory { get; set; }

        public int CourseLevelId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ECourseLevel CourseLevel { get; set; }

        public List<Comments> Comments { get; set; }

        public List<FavouritesProduct> FavouritesProducts { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public byte[] Image { get; set; }

        public bool isAvailable { get; set; }

        public string CompanyName { get; set; }
        public string CompanyWebsite { get; set; }
    }
}
