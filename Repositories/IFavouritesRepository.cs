using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface IFavouritesRepository
    {
        // Task<Favourites> AddProduct(int id, FavouritesCreateDto favouritesDto);
        // Task<Favourites> RemoveProduct(int id, int productId);
        Task<Favourites> GetById(int id);
        Task<Favourites> UpdateFavourites(Favourites favourites, int id);
    }
}
