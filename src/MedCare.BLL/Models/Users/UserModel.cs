using MedCare.DAL.Entities;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Models.Users;

public class UserModel : BaseModel
{
    public string Login { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserRole UserRole { get; set; }

    /// <summary>
    /// Профиль с информацией пользователя
    /// </summary>
    public UserProfileEntity UserProfile { get; set; } = null!;
    public Guid UserProfileId { get; set; }
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public SpecializationEntity? Specialization { get; set; }
    public Guid? SpecializationId { get; set; }
    
    /// <summary>
    /// Филиал, в котором работает работник
    /// </summary>
    public BranchEntity? Branch { get; set; }
    public Guid? BranchId { get; set; }

    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentEntity>? DoctorAppointments { get; set; }
    
    /// <summary>
    /// Записи на прием, где этот user - пациент
    /// </summary>
    public List<AppointmentEntity>? PatientAppointments { get; set; }
    
    /// <summary>
    /// График работы сотрудника (набор записей в shedules для определенных дней недели)
    /// </summary>
    public List<ScheduleEntity>? Schedules { get; set; }
}