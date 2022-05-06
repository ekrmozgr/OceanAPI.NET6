namespace OceanAPI.NET6.Dtos
{
    public class FavouritesReadDto
    {
        public int UserId { get; set; }
        public List<FavouritesProductReadDto> FavouritesProducts { get; set; }
        public int ProductCount { get; set; }
    }
}
