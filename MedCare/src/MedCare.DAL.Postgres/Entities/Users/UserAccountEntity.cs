using MedCare.Common.Models.Users;

namespace MedCare.DAL.Entities.Users;

public class UserAccountEntity : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    
    public string PasswordHash { get; set; } = string.Empty;
    
    public UserRole UserRole { get; set; }
    
    /// <summary>
    /// Связь с профилем пользователя
    /// </summary>
    public UserProfileEntity UserProfileEntity { get; set; } = null!;
    
    public Guid UserProfileId { get; set; }
    
    /// <summary>
    /// Связь с доктором
    /// </summary>
    public DoctorEntity Doctor { get; set; } = null!;
    
    public Guid DoctorId { get; set; }
    
    /// <summary>
    /// Связь с регистратором
    /// </summary>
    public ReceptionistEntity Receptionist { get; set; } = null!;
    
    public Guid ReceptionistId { get; set; }
    
    /// <summary>
    /// Связь c админом
    /// </summary>
    public AdminEntity Admin { get; set; } = null!;
    
    public Guid AdminId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}