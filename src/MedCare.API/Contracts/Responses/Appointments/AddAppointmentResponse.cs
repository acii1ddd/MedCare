using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.API.Contracts.Responses.Appointments;

public class AddAppointmentResponse : BaseModel
{
    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; set; }

    public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.Confirmed;
    
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
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

public class AddAppointmentResponseProfile : Profile
{
    public AddAppointmentResponseProfile()
    {
        CreateMap<AppointmentModel, AddAppointmentResponse>();
    }
}