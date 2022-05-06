namespace OceanAPI.NET6.Dtos
{
    public class FavouritesProductReadDto
    {
        public int FavouritesId { get; set; }
        public int ProductId { get; set; }
        public ProductReadDto Product { get; set; }
    }
}
