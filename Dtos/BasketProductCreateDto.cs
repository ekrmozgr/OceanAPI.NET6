using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class BasketProductCreateDto
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int BasketId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductQuantity { get; set; }
    }
}
