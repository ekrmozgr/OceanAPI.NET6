using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public enum ERoles
    {
        USER = 1,
        INSTRUCTOR = 2,
        ADMIN = 3
    }
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ERoles ERole { get; set; }
    }
}
