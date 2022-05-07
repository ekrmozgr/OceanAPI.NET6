using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class FavouritesCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int FavouritesId { get; set; }
    }
}
