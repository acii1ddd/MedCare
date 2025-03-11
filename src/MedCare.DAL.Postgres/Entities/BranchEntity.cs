using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Entities;

/// <summary>
/// Филиал
/// </summary>
public class BranchEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Адрес филиала
    /// </summary>
    public AddressEntity Address { get; set; }
    
    public Guid AddressId { get; set; }
    
    /// <summary>
    /// Сотрудники, которые работают в этом филиале
    /// </summary>
    public List<WorkerEntity> Workers { get; set; } = [];
    
    /// <summary>
    /// Услуги, которые предоставляет филиал
    /// </summary>
    public List<ServiceEntity> Services { get; set; } = [];
    
    /// <summary>
    /// Записи в регистратуре для данного филиала
    /// </summary>
    public List<AppointmentEntity> Appointments { get; set; } = [];
}