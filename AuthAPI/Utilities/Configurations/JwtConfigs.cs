using AuthAPI.Dtos.Configurations;
using AuthAPI.Interfaces.Configurations;
using Microsoft.Extensions.Options;

namespace AuthAPI.Utilities.Configurations;

public class JwtConfigs(IOptions<JwtOptionsDto> _jwtOptions) : IJwtOptionsConfig
{
    private readonly JwtOptionsDto jwtOptions = _jwtOptions.Value;

    public string GetAudience()
    {
        return jwtOptions.Audience;
    }

    public string GetIssuer()
    {
        return jwtOptions.Issuer;
    }

    public string GetSecret()
    {
        return jwtOptions.Secret;
    }
}
