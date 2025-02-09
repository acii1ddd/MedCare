using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Entities.Cities;
using MedCare.DAL.Entities.Services;

namespace MedCare.DAL.Entities.Branches;

/// <summary>
/// Филиал
/// </summary>
public class BranchEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public string Phone { get; set; } = string.Empty;
    
    /// <summary>
    ///  Адрес филиала
    /// </summary>
    public CityEntity City { get; set; } = null!;
    
    public Guid CityId { get; set; }
    
    public string Street { get; set; } = string.Empty;
    
    public int BuildingNumber { get; set; }
    
    /// <summary>
    /// Услуги, которые предоставляет филиал
    /// </summary>
    public List<ServiceEntity> Services { get; set; } = [];
    
    /// <summary>
    /// Записи в регистратуре для данного филиала
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}