using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class ForgottenPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
