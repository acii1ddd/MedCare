using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Requests;

public class AddMedicalRecordRequest
{
    public string? Diagnosis { get; set; } = string.Empty;
    
    /// <summary>
    /// Предписания по лечению
    /// </summary>
    public string? Treatment { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;

    public Guid AppointmentId { get; set; }
}

public class AddMedicalRecordRequestProfile : Profile
{
    public AddMedicalRecordRequestProfile()
    {
        CreateMap<AddMedicalRecordRequest, MedicalRecordModel>();
    }
}