namespace MedCare.Common.Models.Users;

public class WorkerModel
{
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }
    
    /// <summary>
    /// Профиль с информацией работника
    /// </summary>
    public UserProfileModel UserProfile { get; set; } = null!;
    public Guid UserProfileId { get; set; }
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public SpecializationModel? Specialization { get; set; }
    public Guid? SpecializationId { get; set; }
    
    /// <summary>
    /// Филиал, в котором работает работник
    /// </summary>
    public BranchModel Branch { get; set; } = null!;
    public Guid BranchId { get; set; }
    
    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentModel>? Appointments { get; set; }
}