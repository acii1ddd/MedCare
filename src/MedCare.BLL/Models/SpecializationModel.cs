using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Models;

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
    public List<UserModel> Workers { get; set; } = null!;
}