using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OceanAPI.NET6.Models
{
    public class User
    {
        public User()
        {
            Role = ERoles.USER;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobilePhone { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ERoles Role { get; set; }
        public Basket Basket { get; set; }
        public List<Comments> Comments { get; set; }

        public Favourites Favourites { get; set; }
    }
}
