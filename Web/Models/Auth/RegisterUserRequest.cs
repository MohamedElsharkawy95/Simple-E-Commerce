using System.ComponentModel.DataAnnotations;

namespace Web.Models.Auth;

public class RegisterUserRequest
{
    [Required]
    public required string FullName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

    [Required]
    public required string Phone { get; set; }

    public string? Role { get; set; }
}
