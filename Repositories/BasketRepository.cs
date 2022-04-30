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
        public Basket GetBasket(int id)
        {
            if(_dbSet.Find(id) == null)
                return null;
            var basket = _dbSet.Include(b => b.BasketProducts).ThenInclude(bp => bp.Product).Where(b => b.UserId.Equals(id)).FirstOrDefault();
            return basket;
        }

        public Basket UpdateById(Basket entity, int id)
        {
            var model = _dbSet.Find(id);
            if (model == null)
                return null;
            var response = _context.Entry(model);
            response.State = EntityState.Modified;

            _context.SaveChanges();
            return response.Entity;
        }
    }
}
