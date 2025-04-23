namespace MedCare.DAL.Dto;

public class PopularDoctorsDto
{
    public Guid DoctorId { get; set; }
    
    
    public string DoctorName { get; set; } = string.Empty;
    
    public string SpecializationName { get; set; } = string.Empty;
    
    public int AppointmentCount { get; set; }
}