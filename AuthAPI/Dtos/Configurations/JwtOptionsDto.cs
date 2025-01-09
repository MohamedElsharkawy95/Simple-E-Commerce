using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Dtos.Configurations;

public class JwtOptionsDto
{
    [Required]
    public required string Secret { get; set; }

    [Required]
    public required string Issuer { get; set; }

    [Required]
    public required string Audience { get; set; }
}
