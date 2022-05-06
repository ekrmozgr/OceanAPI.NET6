using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class PurchaseDto
    {
        [Required]
        public int BasketId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
