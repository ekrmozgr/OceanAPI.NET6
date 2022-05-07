using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Order> _dbSet;
        public OrderRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }
        public async Task<Order> AddOrder(Order order)
        {
            await _dbSet.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetOrdersByUserId(int userId)
        {
            return await _dbSet.Include(x => x.OrderProducts).ThenInclude(op => op.Product).Include(x => x.User).Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
