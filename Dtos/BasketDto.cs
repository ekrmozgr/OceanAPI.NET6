using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Dtos
{
    public class BasketDto
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public List<BasketProductReadDto> BasketProducts { get; set; }
    }
}
