namespace MedCare.BLL.Models;

public class MedicalRecordModel : BaseModel
{
    public string? Diagnosis { get; set; } = string.Empty;
    
    /// <summary>
    /// Предписания по лечению
    /// </summary>
    public string? Treatment { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Соответствующий прием пациента по его записи
    /// </summary>
    public AppointmentModel Appointment { get; set; } = null!;
    public Guid AppointmentId { get; set; }
}