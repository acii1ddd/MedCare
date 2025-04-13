using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Requests;

public class AddAppointmentRequest
{
    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; init; }

    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; init; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public Guid? DoctorId { get; init; }
    
    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public Guid ServiceId { get; init; }
}

public class AddAppointmentResponseProfile : Profile
{
    public AddAppointmentResponseProfile()
    {
        CreateMap<AddAppointmentRequest, AppointmentModel>();
    }
}