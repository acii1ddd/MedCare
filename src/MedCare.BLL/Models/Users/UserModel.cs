using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Models.Users;

public class UserModel
{
    public byte[]? Image { get; set; } = [];
    public UserRole UserRole { get; set; }

    /// <summary>
    /// Профиль с информацией пользователя
    /// </summary>
    public UserProfileEntity UserProfile { get; set; } = null!;
    public Guid UserProfileId { get; set; }
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public SpecializationModel? Specialization { get; set; }
    public Guid? SpecializationId { get; set; }
    
    /// <summary>
    /// Филиал, в котором работает работник
    /// </summary>
    public BranchModel? Branch { get; set; }
    public Guid? BranchId { get; set; }
    
    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentModel>? Appointments { get; set; }
}