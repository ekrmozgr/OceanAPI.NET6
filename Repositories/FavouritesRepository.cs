using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Dtos;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Favourites> _dbSet;
        public FavouritesRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Favourites>();
        }
        public Task<Favourites> AddProduct(int id, FavouritesCreateDto favouritesDto)
        {
            throw new NotImplementedException();
        }

        public Task<Favourites> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Favourites> RemoveProduct(int id, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
