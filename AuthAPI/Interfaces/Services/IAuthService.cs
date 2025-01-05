using AuthAPI.Dtos.Users;

namespace AuthAPI.Interfaces.Services;

public interface IAuthService
{
    Task<UserResponse> Regiser(RegisterUserRequest request);
    Task<LoginResponse> Login(LoginRequest request);
}
