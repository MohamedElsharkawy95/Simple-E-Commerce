using AuthAPI.Dtos;
using AuthAPI.Dtos.Users;
using AuthAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ResponseDto>> Register([FromBody] RegisterUserRequest request)
    {
        UserResponse? user = await _authService.Regiser(request);
        ResponseDto responseDto = new ResponseDto
        {
            Result = user
        };
        return Ok(responseDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginRequest request)
    {
        LoginResponse loginResponse = await _authService.Login(request);
        ResponseDto responseDto = new ResponseDto
        {
            Result = loginResponse
        };
        return Ok(responseDto);
    }

    [HttpPost("assign-role")]
    public async Task<ActionResult<ResponseDto>> AssignRole([FromBody] AssignRoleRequest request)
    {
        await _authService.AssignRole(request);
        ResponseDto responseDto = new ResponseDto
        {
            Result = true
        };
        return Ok(responseDto);
    }
}
