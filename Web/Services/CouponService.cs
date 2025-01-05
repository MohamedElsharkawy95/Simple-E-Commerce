using Microsoft.Extensions.Options;
using System;
using Web.Interfaces.Services;
using Web.Models;
using Web.Models.Configurations;
using Web.Models.Coupons;

namespace Web.Services;

public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;
    private readonly IOptions<ServiceUrlDto> _options;

    public CouponService(IBaseService baseService, IOptions<ServiceUrlDto> options)
    {
        _baseService = baseService;
        _options = options;
    }

    public async Task<ResponseDto?> CreateCouponAsync(CouponDto coupon)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.POST,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url,
            Data = coupon
        });
        return response;
    }

    public async Task<ResponseDto?> DeleteCouponAsync(int id)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.DELETE,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url + id
        });
        return response;
    }

    public async Task<ResponseDto?> GetAllCouponsAsync()
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url
        });
        return response;
    }

    public async Task<ResponseDto?> GetCouponByCodeAsync(string code)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url + "GetByCode" + code
        });
        return response;
    }

    public async Task<ResponseDto?> GetCouponByIdAsync(int id)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.GET,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url + "/" + id
        });
        return response;
    }

    public async Task<ResponseDto?> UpdateCouponAsync(CouponDto coupon)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.PUT,
            Url = _options.Value.CouponsUrl?.BaseUrl + _options.Value.CouponsUrl?.Url,
            Data = coupon
        });
        return response;
    }
}
