namespace Web.Interfaces.Services;
using Web.Models;
using Web.Models.Coupons;

public interface ICouponService
{
    public Task<ResponseDto?> GetAllCouponsAsync();
    public Task<ResponseDto?> GetCouponByCodeAsync(string code);
    public Task<ResponseDto?> GetCouponByIdAsync(int id);
    public Task<ResponseDto?> CreateCouponAsync(CouponDto coupon);
    public Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon);
    public Task<ResponseDto?> DeleteCouponAsync(int id);
}
