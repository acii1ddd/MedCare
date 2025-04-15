using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses.Appointments;

public class GetAppointmentResponse
{
    public Guid Id { get; init; }

    /// <summary>
    /// Дата приема врача
    /// </summary>
    public DateTime VisitDate { get; init; }

    public string AppointmentStatus { get; init; } = string.Empty;
    
    public string PaymentStatus { get; init; } = string.Empty;

    /// <summary>
    /// Примечание пациента
    /// </summary>
    public string? Note { get; init; }
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    /// <summary>
    /// Пациент
    /// </summary>
    public Guid PatientId { get; init; }
    
    /// <summary>
    /// Доктор
    /// </summary>
    public Guid? DoctorId { get; init; }
    
    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public Guid ServiceId { get; init; }
}

public class GetAppointmentResponseProfile : Profile
{
    public GetAppointmentResponseProfile()
    {
        CreateMap<AppointmentModel, GetAppointmentResponse>()
            .ForMember(dest => dest.AppointmentStatus, opt 
                => opt.MapFrom(src => src.AppointmentStatus.ToString()))
            .ForMember(dest => dest.PaymentStatus, opt 
                => opt.MapFrom(src => src.PaymentStatus.ToString()));
    }
}