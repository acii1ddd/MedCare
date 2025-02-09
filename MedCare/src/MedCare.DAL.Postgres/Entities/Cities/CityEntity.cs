using MedCare.DAL.Entities.Branches;

namespace MedCare.DAL.Entities.Cities;

public class CityEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public List<BranchEntity> Branches { get; set; } = [];
}