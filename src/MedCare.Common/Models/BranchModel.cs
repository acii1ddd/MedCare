using MedCare.Common.Models.Users;

namespace MedCare.Common.Models;

public class BranchModel
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Адрес филиала
    /// </summary>
    public AddressModel Address { get; set; } = null!;
    public Guid AddressId { get; set; }
    
    /// <summary>
    /// Сотрудники, которые работают в этом филиале
    /// </summary>
    public List<WorkerModel> Workers { get; set; } = [];
    
    /// <summary>
    /// Услуги, которые предоставляет филиал
    /// </summary>
    public List<ServiceModel> Services { get; set; } = [];
    
    /// <summary>
    /// Записи в регистратуре для данного филиала
    /// </summary>
    public List<AppointmentModel> Appointments { get; set; } = [];
}