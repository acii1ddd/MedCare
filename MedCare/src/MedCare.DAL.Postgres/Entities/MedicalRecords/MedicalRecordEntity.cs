using MedCare.DAL.Entities.Appointments;

namespace MedCare.DAL.Entities.MedicalRecords;

/// <summary>
/// Медицинские записи пациентов
/// </summary>
public class MedicalRecordEntity : BaseEntity
{
    /// <summary>
    /// Соответствующий прием пациента по его записи
    /// </summary>
    public AppointmentEntity Appointment { get; set; } = null!;
    
    public Guid AppointmentId { get; set; }
    
    public string? Diagnosis { get; set; } = string.Empty;
    
    /// <summary>
    /// Предписания по лечению
    /// </summary>
    public string? Treatment { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}