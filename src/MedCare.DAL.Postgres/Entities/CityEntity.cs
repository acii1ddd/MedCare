namespace MedCare.DAL.Entities;

public class CityEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Адреса этого города
    /// </summary>
    public List<AddressEntity> Addresses { get; set; } = [];
}