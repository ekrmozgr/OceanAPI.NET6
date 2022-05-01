using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class Product
    {
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
    }
}
