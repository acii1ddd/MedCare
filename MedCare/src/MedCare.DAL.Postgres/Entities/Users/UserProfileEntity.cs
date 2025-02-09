namespace MedCare.DAL.Entities.Users;

public class UserProfileEntity : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string Patronymic { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    /// <summary>
    /// Связь с аккаунтом пользователя (для авторизации)
    /// </summary>
    public UserAccountEntity UserAccount { get; set; } = null!;
    
    public Guid UserAccountId { get; set; }
}