using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Interfaces.Services;
using Web.Models;
using Web.Models.Coupons;

namespace Web.Controllers;

public class CouponsController : Controller
{
    private readonly ICouponService _couponService;

    public CouponsController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    public async Task<IActionResult> Index()
    {
        List<CouponDto>? coupons = new List<CouponDto>();

        ResponseDto? response = await _couponService.GetAllCouponsAsync();

        if (response != null && response.IsSuccess)
        {
            coupons = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(coupons);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CouponDto coupon)
    {
        if (ModelState.IsValid)
        {
            ResponseDto? response = await _couponService.CreateCouponAsync(coupon);
            if (response != null && response.IsSuccess)
            {
                RedirectToAction(nameof(Index));
            }
        }
        return View(coupon);
    }

    public async Task<IActionResult> Delete(int couponId)
    {
        ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

        if (response != null && response.IsSuccess)
        {
            CouponDto? coupon = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
            return View(coupon);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(CouponDto coupon)
    {
        ResponseDto? response = await _couponService.DeleteCouponAsync(coupon.Id);

        if (response != null && response.IsSuccess)
        {
            RedirectToAction(nameof(Index));
        }
        return View(coupon);
    }
}
