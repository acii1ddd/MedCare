namespace MedCare.BLL.Models.Auth;

public class AuthSettings
{
    public string Issuer { get; init; } = string.Empty;
    
    public string Audience { get; init; } = string.Empty;
    
    public double LifeTime { get; init; }
    
    public string Secret { get; init; } = string.Empty;
}