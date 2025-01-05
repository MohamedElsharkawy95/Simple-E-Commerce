using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models;

public class User : IdentityUser
{
    public required string FullName { get; set; }
}
