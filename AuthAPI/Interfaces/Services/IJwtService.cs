using AuthAPI.Models;

namespace AuthAPI.Interfaces.Services;

public interface IJwtService
{
    string GenerateJwt(User user);
}
