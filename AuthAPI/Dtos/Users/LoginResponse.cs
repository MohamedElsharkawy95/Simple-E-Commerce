namespace AuthAPI.Dtos.Users;

public class LoginResponse
{
    public UserResponse? User { get; set; }
    public string Token { get; set; } = string.Empty;
}
