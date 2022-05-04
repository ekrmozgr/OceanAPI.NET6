using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class CommentsCreateDto
    {
        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
