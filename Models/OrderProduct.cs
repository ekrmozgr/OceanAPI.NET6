using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
