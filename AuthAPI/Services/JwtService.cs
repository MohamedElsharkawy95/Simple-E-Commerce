using AuthAPI.Interfaces.Configurations;
using AuthAPI.Interfaces.Services;
using AuthAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services;

public class JwtService : IJwtService
{
    private readonly IJwtOptionsConfig _jwtConfigs;

    public JwtService(IJwtOptionsConfig jwtConfigs)
    {
        _jwtConfigs = jwtConfigs;
    }

    public string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_jwtConfigs.GetSecret());

        var claims = PrepareClaims(user);

        var tokenDescriptor = PrepareTokenDescriptor(key, claims);

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private static List<Claim> PrepareClaims(User user)
    {
        return new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!)
        };
    }

    private SecurityTokenDescriptor PrepareTokenDescriptor(byte[]? key, List<Claim> claims)
    {
        return new SecurityTokenDescriptor
        {
            Issuer = _jwtConfigs.GetIssuer(),
            Audience = _jwtConfigs.GetAudience(),
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
    }
}
