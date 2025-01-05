using AuthAPI.Dtos.Configurations;
using AuthAPI.Interfaces.Services;
using AuthAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services;

public class JwtService : IJwtService
{
    private readonly JwtOptionsDto _jwtOptions;

    public JwtService(IOptions<JwtOptionsDto> jwtOptions)
    { 
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

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
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
    }
}
