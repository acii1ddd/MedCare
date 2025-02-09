namespace MedCare.DAL.Entities.Users;

public class ReceptionistEntity : BaseEntity
{
    /// <summary>
    /// Аккаунт регистратора
    /// </summary>
    public UserAccountEntity UserAccount { get; set; } = null!;
    
    public Guid UserAccountId { get; set; }
    
    // график работы регистратора
}
