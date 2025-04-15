using AutoMapper;
using MedCare.API.Contracts.Responses.Appointments;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses.MedicalRecords;

public class AddMedicalRecordResponse
{
    public string? Diagnosis { get; init; } = string.Empty;
    
    /// <summary>
    /// Предписания по лечению
    /// </summary>
    public string? Treatment { get; init; } = string.Empty;
    
    public string? Description { get; init; } = string.Empty;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public GetAppointmentResponse Appointment { get; init; } = null!;
}

public class AddMedicalRecordResponseProfile : Profile
{
    public AddMedicalRecordResponseProfile()
    {
        CreateMap<MedicalRecordModel, AddMedicalRecordResponse>();
    }
}