namespace MedCare.DAL.Entities;

public class AddressEntity : BaseEntity
{
    public string Street { get; set; } = string.Empty;
    
    public int BuildingNumber { get; set; }
    
    /// <summary>
    /// Филиал по этому адресу
    /// </summary>
    public BranchEntity Branch { get; set; }
    
    /// <summary>
    /// Город, в котором находится этот адрес
    /// </summary>
    public CityEntity City { get; set; }
    
    public Guid CityId { get; set; }
}