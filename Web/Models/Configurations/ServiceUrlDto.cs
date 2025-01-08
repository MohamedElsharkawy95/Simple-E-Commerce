using Web.Models.Configurations.Auth;
using Web.Models.Configurations.Coupons;

namespace Web.Models.Configurations;

public class ServiceUrlDto
{
    public CouponUrlDto? CouponsUrl { get; set; }
    public AuthUrlDto? AuthUrl { get; set; }
}
