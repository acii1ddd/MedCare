using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Models.Auth;

public class AuthAccessTokenModel
{
    public required Guid UserId { get; set; }
    
    public required UserRole UserRole { get; set; }
    
    public required string AccessToken { get; set; }
    
    public required DateTime Expires { get; set; }
}