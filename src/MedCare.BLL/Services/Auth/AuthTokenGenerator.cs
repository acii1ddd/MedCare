using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MedCare.BLL.Models.Auth;
using Microsoft.IdentityModel.Tokens;

namespace MedCare.BLL.Services.Auth;

public static class AuthTokenGenerator
{
    public static AuthAccessTokenModel GenerateAccessToken(
        GenerateTokenPayload payload, 
        AuthSettings authSettings)
    {
        
        // дата окончания времени жизни токена
        var expires = DateTime.UtcNow.AddMinutes(authSettings.LifeTime);

        var tokenHandler = new JwtSecurityTokenHandler();
        var claims = new List<Claim>
        {
            new("userId", payload.UserId.ToString()),
            new(ClaimTypes.Role, payload.UserRole.ToString()) // doctor 
        };

        var description = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = authSettings.Issuer,
            Audience = authSettings.Audience,
            Expires = expires,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Secret)),
                SecurityAlgorithms.HmacSha256Signature
            )
        };
        
        var securityToken = tokenHandler.CreateToken(description);
        var token = tokenHandler.WriteToken(securityToken);
        
        return new AuthAccessTokenModel
        {
            UserId = payload.UserId,
            UserRole = payload.UserRole,
            AccessToken = token,
            Expires = expires
        };
    }
}