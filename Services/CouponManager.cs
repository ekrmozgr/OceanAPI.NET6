using OceanAPI.NET6.Models;
using OceanAPI.NET6.Repositories;

namespace OceanAPI.NET6.Services
{
    public class CouponManager : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        public CouponManager(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            return await _couponRepository.AddCoupon(coupon);
        }

        public string GenerateCoupon()
        {
            return "GeneratedCoupon";
        }

        public async Task<List<Coupon>> GetCouponsByUser(int userId)
        {
            return await _couponRepository.GetCouponsByUser(userId);
        }
    }
}
