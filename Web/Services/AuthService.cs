using Web.Interfaces.Configurations;
using Web.Interfaces.Services;
using Web.Interfaces.Services.Configurations;
using Web.Models;
using Web.Models.Auth;

namespace Web.Services;

public class AuthService : IAuthService
{
    private readonly IBaseService _baseService;
    private readonly IAuthUrlConfigs _authUrlConfigs;

    public AuthService(IBaseService baseService, IAuthUrlConfigs authUrlConfigs)
    {
        _baseService = baseService;
        _authUrlConfigs = authUrlConfigs;
    }

    public async Task<ResponseDto?> AssignAsync(AssignRoleRequest request)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.POST,
            Url = _authUrlConfigs.GetBaseUrl() + _authUrlConfigs.GetAuthUrl() + "/assign-role",
            Data = request
        });
        return response;
    }

    public async Task<ResponseDto?> LoginAsync(LoginRequest request)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.POST,
            Url = _authUrlConfigs.GetBaseUrl() + _authUrlConfigs.GetAuthUrl() + "/login",
            Data = request
        });
        return response;
    }

    public async Task<ResponseDto?> RegiserAsync(RegisterUserRequest request)
    {
        ResponseDto response = await _baseService.SendAsync(new RequestDto
        {
            ApiType = Utilities.Enums.ApiType.POST,
            Url = _authUrlConfigs.GetBaseUrl() + _authUrlConfigs.GetAuthUrl() + "/register",
            Data = request
        });
        return response;
    }
}
