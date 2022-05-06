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

        public async Task<Favourites> GetById(int id)
        {
            return await _dbSet.Include(x => x.FavouritesProducts).ThenInclude(fp => fp.Product).ThenInclude(p => p.User).SingleOrDefaultAsync(x =>x.UserId.Equals(id));
        }

        public async Task<Favourites> UpdateFavourites(Favourites favourites, int id)
        {
            var model = await _dbSet.FindAsync(id);
            if (model == null)
                return null;
            var response = _context.Entry(model);
            response.State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return response.Entity;
        }
    }
}
