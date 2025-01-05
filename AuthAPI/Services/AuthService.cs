using AuthAPI.Data;
using AuthAPI.Dtos.Users;
using AuthAPI.Exceptions;
using AuthAPI.Interfaces.Services;
using AuthAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Runtime.ConstrainedExecution;

namespace AuthAPI.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtService _jwtService;


    public AuthService(AppDbContext dbContext, 
        UserManager<User> userManager, 
        RoleManager<IdentityRole> roleManager,
        IJwtService jwtService)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        User? user = _dbContext.Users.FirstOrDefault(u => u.Email!.ToLower() == request.Email.ToLower());
        
        if (user is null)
        {
            return new LoginResponse();
        }

        bool isVaild = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isVaild)
        {
            return new LoginResponse();
        }

        var token = _jwtService.GenerateJwt(user);

        var loginResponse = new LoginResponse()
        {
            User = new UserResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            },
            Token = token
        };

        return loginResponse;
    }

    public async Task<UserResponse?> Regiser(RegisterUserRequest request)
    {
        User user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            NormalizedEmail = request.Email.ToUpper(),
            UserName = request.Email,
            NormalizedUserName = request.Email.ToUpper(),
            PhoneNumber = request.Phone
        };

        try
        {
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                User createdUser = _dbContext.Users.First(u => u.UserName == user.Email);
                return new UserResponse
                {
                    Id = createdUser.Id,
                    FullName = createdUser.FullName,
                    Email = createdUser.Email,
                    PhoneNumber = createdUser.PhoneNumber,
                };
            }
            else
            {
                throw new UserFailedCreationException(result.Errors.FirstOrDefault().Description);
            }
        }
        catch (Exception ex)
        {
            throw new UserFailedCreationException(ex.Message);
        }
    }
}
