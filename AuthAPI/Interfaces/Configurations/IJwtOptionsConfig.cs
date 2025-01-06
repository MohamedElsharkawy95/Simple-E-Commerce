namespace AuthAPI.Interfaces.Configurations;

public interface IJwtOptionsConfig
{
    string GetSecret();
    string GetIssuer();
    string GetAudience();
}
