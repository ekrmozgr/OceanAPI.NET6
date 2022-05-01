using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Models
{
    public class Basket
    {
        [Key]
        public int UserId { get; set; }
        public User User { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public List<BasketProduct> BasketProducts { get; set; }
    }
}
