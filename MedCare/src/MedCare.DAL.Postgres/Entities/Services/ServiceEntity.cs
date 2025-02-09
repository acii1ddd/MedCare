using MedCare.DAL.Entities.Branches;
using MedCare.DAL.Entities.Specializations;

namespace MedCare.DAL.Entities.Services;

/// <summary>
/// Услуга
/// </summary>
public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public decimal? Price { get; set; }

    public SpecializationEntity Specialization { get; set; } = null!;
    
    public Guid SpecializationId { get; set; }
    
    /// <summary>
    /// Филиалы, в которых может оказываться данная услуга
    /// </summary>
    public List<BranchEntity> Branches { get; set; } = [];
}