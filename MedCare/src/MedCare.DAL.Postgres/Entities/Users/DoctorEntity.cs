using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Entities.Branches;
using MedCare.DAL.Entities.Specializations;

namespace MedCare.DAL.Entities.Users;

public class DoctorEntity : BaseEntity
{
    /// <summary>
    /// Аккаунт доктора
    /// </summary>
    public UserAccountEntity UserAccount { get; set; } = null!;
    
    public Guid UserAccountId { get; set; }
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public SpecializationEntity Specialization { get; set; } = null!;
        
    public Guid SpecializationId { get; set; }
    
    /// <summary>
    /// Филиал, в котором работает доктор
    /// </summary>
    public BranchEntity Branch { get; set; } = null!;
    
    public Guid BranchId { get; set; }
    
    // график работы
    
    /// <summary>
    /// Записи на прием к этому доктору
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}