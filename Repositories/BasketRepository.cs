using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Basket> _dbSet;

        public BasketRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Basket>();
        }
        public async Task<Basket> GetBasket(int id)
        {
            if(await _dbSet.FindAsync(id) == null)
                return null;
            var basket = await _dbSet.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).Where(b => b.UserId.Equals(id)).FirstOrDefaultAsync();
            return basket;
        }

        public async Task<Basket> UpdateById(Basket entity, int id)
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
