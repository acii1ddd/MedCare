using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Models;

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
    public List<UserModel> Workers { get; set; } = [];
    
    /// <summary>
    /// Услуги, которые предоставляет филиал
    /// </summary>
    public List<ServiceModel> Services { get; set; } = [];
}