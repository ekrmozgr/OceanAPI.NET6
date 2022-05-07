using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum ERoles
    {
        [Display(Name = "User")]
        USER = 1,
        [Display(Name = "Instructor")]
        INSTRUCTOR = 2,
        [Display(Name = "Admin")]
        ADMIN = 3
    }
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ERoles ERole { get; set; }
    }
}
