using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Minimum eight characters, at least one letter, one number and one special character max 15 char
        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,15}$")]
        public string Password { get; set; }
    }
}
