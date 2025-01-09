using AuthAPI.Data;
using AuthAPI.Dtos.Users;
using AuthAPI.Exceptions;
using AuthAPI.Interfaces.Services;
using AuthAPI.Models;
using Azure.Core;
using Microsoft.AspNetCore.Identity;

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
            throw new UserCreationFailedException(result.Errors.FirstOrDefault().Description);
        }

    }

    public async Task AssignRole(AssignRoleRequest request)
    {
        User? user = _dbContext.Users.FirstOrDefault(u => u.Email!.ToLower() == request.Email.ToLower());

        if (user == null) { throw new UserNotFoundException(request.Email); }

        var isRoleExists = await _roleManager.RoleExistsAsync(request.RoleName);

        if (!isRoleExists)
        {
            var roleCreationResult = await _roleManager.CreateAsync(new IdentityRole { Name = request.RoleName, NormalizedName = request.RoleName.ToUpper() });

            if (!roleCreationResult.Succeeded) { throw new RoleCreationFailedException(roleCreationResult.Errors.FirstOrDefault()?.Description); }
        }

        await AddRoleToUser(user, request.RoleName);
    }

    private async Task AddRoleToUser(User user, string role)
    {
        var roleAssigningResult = await _userManager.AddToRoleAsync(user, role);

        if (!roleAssigningResult.Succeeded) { throw new AssignRoleFailedException(role, user.Email!); }
    }
}
