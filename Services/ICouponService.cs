using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Services
{
    public interface ICouponService
    {
        Task<Coupon> AddCoupon(Coupon coupon);
        Task<List<Coupon>> GetCouponsByUser(int userId);
        string GenerateCoupon();
    }
}
