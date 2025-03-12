namespace MedCare.Common.Models.Users;

public class UserProfileModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Профиль есть у пациента
    /// </summary>
    public PatientModel Patient { get; set; } = null!;
    
    /// <summary>
    /// Профиль есть у работника
    /// </summary>
    public WorkerModel Worker { get; set; } = null!;
}