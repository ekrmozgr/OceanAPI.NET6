using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class FavouritesManager : IFavouritesService
    {
        private readonly IFavouritesRepository _favouritesRepository;
        public FavouritesManager(IFavouritesRepository favouritesRepository)
        {
            _favouritesRepository = favouritesRepository;
        }

        public async Task<Favourites> AddProduct(FavouritesProduct favouritesProduct)
        {
            var favourites = await _favouritesRepository.GetById(favouritesProduct.FavouritesId);
            if (favourites.FavouritesProducts.Find(x => x.ProductId.Equals(favouritesProduct.ProductId)) != null)
                return null;
            favourites.FavouritesProducts.Add(favouritesProduct);
            favourites.ProductCount += 1;
            return await _favouritesRepository.UpdateFavourites(favourites, favouritesProduct.FavouritesId);
        }

        public async Task<Favourites> GetFavouritesById(int id)
        {
            return await _favouritesRepository.GetById(id);
        }

        public async Task<FavouritesProduct> RemoveProduct(int id, int ProductId)
        {
            var favourites = await _favouritesRepository.GetById(id);
            if (favourites == null)
                return null;
            var product = favourites.FavouritesProducts.Find(x => x.ProductId.Equals(ProductId));
            if (product == null)
                return null;
            favourites.FavouritesProducts.Remove(product);
            favourites.ProductCount -= 1;
            await _favouritesRepository.UpdateFavourites(favourites, id);
            return product;
        }
    }
}
