using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Data;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Coupon> _dbSet;
        public CouponRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<Coupon>();
        }
        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            await _dbSet.AddAsync(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<List<Coupon>> GetCouponsByUser(int userId)
        {
            return await _dbSet.Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
