namespace MedCare.BLL.Models;

public class AddressModel
{
    public string Street { get; set; } = string.Empty;
    public int BuildingNumber { get; set; }
    
    /// <summary>
    /// Город, в котором находится этот адрес
    /// </summary>
    public CityModel City { get; set; } = null!;
    public Guid CityId { get; set; }
    
    /// <summary>
    /// Филиал по этому адресу
    /// </summary>
    public BranchModel Branch { get; set; } = null!;
}