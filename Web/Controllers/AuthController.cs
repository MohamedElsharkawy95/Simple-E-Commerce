using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Interfaces.Services;
using Web.Models.Auth;
using Web.Utilities.Constants;

namespace Web.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        var roles = new List<SelectListItem>()
        {
            new SelectListItem(){Text = Roles.CUSTOMER, Value = Roles.CUSTOMER},
            new SelectListItem(){Text = Roles.ADMIN, Value = Roles.ADMIN}
        };
        ViewBag.RolesList = roles;
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Logout()
    {
        return View();
    }
}
