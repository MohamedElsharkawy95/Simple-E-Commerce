
using CouponAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers;

public class CouponsController : BaseController
{
    public CouponsController(AppDbContext context) : base(context)
    {

    }

    [HttpGet]
    public ResponseDto Get()
    {
        ResponseDto responseDto = new ResponseDto();
        try
        {
            responseDto.Result = _context.Coupons.ToList();
            return responseDto;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }

        return responseDto;
    }

    [HttpGet("{id}")]
    public ResponseDto Get([FromRoute] int id)
    {
        ResponseDto responseDto = new ResponseDto();
        try
        {
            responseDto.Result = _context.Coupons.FirstOrDefault(s => s.Id == id);
            return responseDto;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.Message = ex.Message;
        }

        return responseDto;
    }
}
