namespace MedCare.BLL.Models;

public class CityModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Адреса этого города
    /// </summary>
    public List<AddressModel> Addresses { get; set; } = [];
}