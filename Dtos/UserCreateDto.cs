using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Dtos
{
    public class UserCreateDto
    {
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobilePhone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
