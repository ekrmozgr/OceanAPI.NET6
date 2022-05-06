using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface IFavouritesService
    {
        public Task<Favourites> AddProduct(FavouritesProduct favouritesProduct);

        public Task<FavouritesProduct> RemoveProduct(int id, int ProductId);

        public Task<Favourites> GetFavouritesById(int id);
    }
}
