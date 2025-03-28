using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Models.Auth;

public class GenerateTokenPayload
{
    public Guid UserId { get; set; }
   
    public UserRole UserRole { get; set; }
}