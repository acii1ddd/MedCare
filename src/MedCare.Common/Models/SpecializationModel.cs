using MedCare.Common.Models.Users;

namespace MedCare.Common.Models;

public class SpecializationModel
{
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Услуги этой специализации
    /// </summary>
    public List<ServiceModel> Services { get; set; } = null!;
    
    /// <summary>
    /// Сотрудники этой специализации
    /// </summary>
    public List<WorkerModel> Workers { get; set; } = null!;
}