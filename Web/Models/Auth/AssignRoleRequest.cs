using System.ComponentModel.DataAnnotations;

namespace Web.Models.Auth;

public class AssignRoleRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string RoleName { get; set; }
}
