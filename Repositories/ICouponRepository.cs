using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> AddCoupon(Coupon coupon);
        Task<List<Coupon>> GetCouponsByUser(int userId);
    }
}
