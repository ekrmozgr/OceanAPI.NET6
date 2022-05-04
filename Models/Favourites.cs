using System.ComponentModel.DataAnnotations;

namespace OceanAPI.NET6.Models
{
    public class Favourites
    {
        public Favourites()
        {
            ProductCount = 0;
        }

        [Key]
        public int UserId { get; set; }

        public User User { get; set; }

        public List<FavouritesProduct> FavouritesProducts { get; set; }

        public int ProductCount { get; set; }
    }
}
