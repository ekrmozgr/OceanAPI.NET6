using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class Order
    {
        public Order()
        {
            DateOfOrder = DateTime.Now;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }


        public List<OrderProduct> OrderProducts { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string RecipientMail { get; set; }

        public List<Coupon> Coupons { get; set; }
    }
}
