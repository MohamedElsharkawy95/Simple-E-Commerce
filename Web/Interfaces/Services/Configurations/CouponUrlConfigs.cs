using Microsoft.Extensions.Options;
using Web.Interfaces.Configurations;
using Web.Models.Configurations.Coupons;

namespace Web.Interfaces.Services.Configurations;

public class CouponUrlConfigs(IOptions<CouponUrlDto> _couponUrlOptions) : ICouponUrlConfigs
{
    private readonly CouponUrlDto couponUrlOptions = _couponUrlOptions.Value;

    public string GetBaseUrl()
    {
        return couponUrlOptions.BaseUrl;
    }

    public string GetCouponUrl()
    {
        return couponUrlOptions.Url;
    }
}
