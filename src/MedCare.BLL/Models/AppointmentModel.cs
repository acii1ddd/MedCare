using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.BLL.Models;

public class AppointmentModel
{
    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Пациент
    /// </summary>
    public UserModel Patient { get; set; } = null!;
    public Guid PatientId { get; set; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public UserModel? Doctor { get; set; }
    public Guid? DoctorId { get; set; }
    
    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public ServiceModel Service { get; set; } = null!;
    public Guid ServiceId { get; set; }
    
    /// <summary>
    /// Медицинские записи, связанные с этим приемом (добавляет врач)
    /// </summary>
    public List<MedicalRecordModel> MedicalRecords { get; set; } = null!;
}