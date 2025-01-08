using Web.Interfaces.Configurations;
using Web.Interfaces.Services;
using Web.Models;
using Web.Models.Coupons;

namespace Web.Services;

public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;
    private readonly ICouponUrlConfigs _couponUrlConfigs;

    public CouponService(IBaseService baseService, ICouponUrlConfigs couponUrlConfigs)
    {
        _baseService = baseService;
        _couponUrlConfigs = couponUrlConfigs;
    }

    public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupon)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.POST,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl(),
            Data = coupon
        });
        return response;
    }

    public async Task<ResponseDto?> DeleteCouponAsync(int id)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.DELETE,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl() + "/" + id
        });
        return response;
    }

    public async Task<ResponseDto?> GetAllCouponsAsync()
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl()
        });
        return response;
    }

    public async Task<ResponseDto?> GetCouponByCodeAsync(string code)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl() + "GetByCode" + code
        });
        return response;
    }

    public async Task<ResponseDto?> GetCouponByIdAsync(int id)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl() + "/" + id
        });
        return response;
    }

    public async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.PUT,
            Url = _couponUrlConfigs.GetBaseUrl() + _couponUrlConfigs.GetCouponUrl(),
            Data = coupon
        });
        return response;
    }
}
