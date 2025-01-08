using Microsoft.Extensions.Options;
using Web.Interfaces.Configurations;
using Web.Models.Configurations.Auth;

namespace Web.Interfaces.Services.Configurations;

public class AuthUrlConfigs(IOptions<AuthUrlDto> _authUrlOptions) : IAuthUrlConfigs
{
    private readonly AuthUrlDto authUrlOptions = _authUrlOptions.Value;

    public string GetBaseUrl()
    {
        return authUrlOptions.BaseUrl;
    }

    public string GetAuthUrl()
    {
        return authUrlOptions.Url;
    }
}
