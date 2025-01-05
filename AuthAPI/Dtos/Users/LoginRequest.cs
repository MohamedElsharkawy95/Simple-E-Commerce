﻿using System.ComponentModel.DataAnnotations;

namespace AuthAPI.Dtos.Users;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(8)]
    public required string Password { get; set; }
}
