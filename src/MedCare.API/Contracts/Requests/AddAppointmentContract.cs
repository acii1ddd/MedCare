using MedCare.BLL.Models;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.API.Contracts.Requests;

public class AddAppointmentRequestContract
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
    
    /// <summary>
    /// Пациент
    /// </summary>
    public Guid PatientId { get; set; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public Guid? DoctorId { get; set; }
    
    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public Guid ServiceId { get; set; }
}