namespace MedCare.DAL.Dto;

public class PopularServicesDto
{
    public Guid ServiceId { get; set; }

    public string ServiceName { get; set; } = string.Empty;

    public int AppointmentCount { get; set; }
}