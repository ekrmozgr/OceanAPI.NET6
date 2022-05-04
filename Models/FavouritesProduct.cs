namespace OceanAPI.NET6.Models
{
    public class FavouritesProduct
    {
        public int FavouritesId { get; set; }
        public Favourites Favourites { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
