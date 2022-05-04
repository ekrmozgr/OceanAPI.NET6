using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Surname { get; set; }
        [Required]
        [Phone]
        public string MobilePhone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        //[RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,15}$")]
        public string Password { get; set; }
    }
}
