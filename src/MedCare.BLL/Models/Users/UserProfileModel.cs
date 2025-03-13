using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Models.Users;

public class UserProfileModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Профиль пользователя
    /// </summary>
    public UserModel User { get; set; } = null!;
}