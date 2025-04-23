namespace MedCare.DAL.Dto;

public class PopularSpecializationDto
{
    public Guid SpecializationId { get; set; }

    public string SpecializationName { get; set; } = string.Empty;
    
    public int AppointmentCount { get; set; }
}