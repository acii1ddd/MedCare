using MedCare.Common.Models.Appointments;
using MedCare.DAL.Entities.Branches;
using MedCare.DAL.Entities.MedicalRecords;
using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Entities.Appointments;

/// <summary>
/// Записи на прием (запись в регистратуре)
/// </summary>
public class AppointmentEntity : BaseEntity
{
    /// <summary>
    /// Пациент
    /// </summary>
    public PatientEntity Patient { get; set; } = null!;
    
    public Guid PatientId { get; set; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public DoctorEntity Doctor { get; set; } = null!;
    
    public Guid DoctorId { get; set; }
    
    /// <summary>
    /// Филиал для записи 
    /// </summary>
    public BranchEntity Branch { get; set; } = null!;
    
    public Guid BranchId { get; set; }
    
    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; set; }
    
    public AppointmentStatus Status { get; set; }
    
    /// <summary>
    ///  Медицинские записи, связанные с этим приемом (добавляет врач)
    /// </summary>
    public List<MedicalRecordEntity> MedicalRecords { get; set; } = null!;
    
    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}