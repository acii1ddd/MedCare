using AutoMapper;
using MedCare.API.Contracts.Responses.MedicalRecords;
using MedCare.API.Contracts.Responses.Workers;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses.Appointments;

public class GetAppointmentResponseWithCards
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
    /// Доктор
    /// </summary>
    public GetSmallDoctorResponse Doctor { get; init; } = null!;

    /// <summary>
    /// Услуга, предоставляемая пациенту в рамках этого приема
    /// </summary>
    public GetServiceResponse Service { get; init; } = null!;
    
    public GetPatientResponse Patient { get; init; } = null!;
    
    /// <summary>
    /// Медицинские записи, связанные с этим приемом (добавляет врач)
    /// </summary>
    public List<GetMedicalRecordResponse> MedicalRecords { get; init; } = null!;
}

public class GetAppointmentResponseWithCardsProfile : Profile
{
    public GetAppointmentResponseWithCardsProfile()
    {
        CreateMap<AppointmentModel, GetAppointmentResponseWithCards>()
            .ForMember(dest => dest.AppointmentStatus, opt 
                => opt.MapFrom(src => src.AppointmentStatus.ToString()))
            .ForMember(dest => dest.PaymentStatus, opt 
                => opt.MapFrom(src => src.PaymentStatus.ToString()));
    }
}