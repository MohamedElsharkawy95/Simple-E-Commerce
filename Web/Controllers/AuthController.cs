using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
        ViewBag.RolesList = GetRoles();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserRequest request)
    {
        var registerationResponse = await _authService.RegiserAsync(request);

        if (registerationResponse != null && registerationResponse.IsSuccess && !string.IsNullOrEmpty(request.Role))
        {

            AssignRoleRequest assignRoleRequest = new() { Email = request.Email, RoleName = request.Role };
            var roleAssigningRoleResponse = await _authService.AssignAsync(assignRoleRequest);

            if (roleAssigningRoleResponse != null && roleAssigningRoleResponse.IsSuccess)
            {
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction(nameof(Login));
            }
        }

        ViewBag.RolesList = GetRoles();
        return View(request);
    }

    private static List<SelectListItem> GetRoles()
    {
        var roles = new List<SelectListItem>()
        {
            new SelectListItem(){Text = Roles.CUSTOMER, Value = Roles.CUSTOMER},
            new SelectListItem(){Text = Roles.ADMIN, Value = Roles.ADMIN}
        };

        return roles;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var responseDto = await _authService.LoginAsync(request);
        if (responseDto != null && responseDto.IsSuccess) 
        {
            LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(Convert.ToString(responseDto.Result));
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError("CustomerError", responseDto.Message);
            return View(request);
        }
    }

    [HttpGet]
    public IActionResult Logout()
    {
        return View();
    }
}
