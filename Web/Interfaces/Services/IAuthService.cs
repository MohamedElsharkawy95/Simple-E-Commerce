using Web.Models;
using Web.Models.Auth;

namespace Web.Interfaces.Services;

public interface IAuthService
{
    Task<ResponseDto?> RegiserAsync(RegisterUserRequest request);
    Task<ResponseDto?> LoginAsync(LoginRequest request);
    Task<ResponseDto?> AssignAsync(AssignRoleRequest request);
}
