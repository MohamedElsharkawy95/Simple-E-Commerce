namespace AuthAPI.Interfaces.Configurations;

public interface IJwtConfig
{
    string GetSecret();
    string GetIssuer();
    string GetAudience();
}
