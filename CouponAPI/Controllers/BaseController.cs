using CouponAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly AppDbContext _context;

    public BaseController(AppDbContext context)
    {
        _context = context;
    }
}
