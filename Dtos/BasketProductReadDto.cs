using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Dtos
{
    public class BasketProductReadDto
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public ProductReadDto Product { get; set; }
    }
}
