namespace CouponAPI.Models;

public class Coupon : BaseModel
{
    public required string Code { get; set; }
    public required double DiscountAmount { get; set; }
    public int? MinAmount { get; set; }
}
