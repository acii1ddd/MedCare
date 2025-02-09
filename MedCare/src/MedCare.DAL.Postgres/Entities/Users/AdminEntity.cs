namespace MedCare.DAL.Entities.Users;

public class AdminEntity : BaseEntity
{
    /// <summary>
    /// Аккаунт администратора
    /// </summary>
    public UserAccountEntity UserAccount { get; set; } = null!;
    
    public Guid UserAccountId { get; set; }
}
