using MedCare.Common.Models;
using MedCare.Common.Models.Users.Patient;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.DAL.Entities.Users;

public class PatientEntity : BaseEntity
{
    // подумать над выносом в user профиль
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string Patronymic { get; set; } = string.Empty;
    
    public DateTime BirthDate { get; set; }
    
    public Gender Gender { get; set; }
    
    public string Email { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Записи этого пациента на прием
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}