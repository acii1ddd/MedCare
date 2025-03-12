namespace MedCare.Common.Models.Users;

public class PatientModel
{
    /// <summary>
    /// Профиль с информацией пациента
    /// </summary>
    public UserProfileModel UserProfile { get; set; } = null!;   
    public Guid UserProfileId { get; set; }

    /// <summary>
    /// Записи этого пациента на прием
    /// </summary>
    public List<AppointmentModel> Appointments { get; set; } = [];
}