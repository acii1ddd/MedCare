using MedCare.DAL.Entities.Services;

namespace MedCare.DAL.Entities.Specializations;

/// <summary>
/// Направление
/// </summary>
public class SpecializationEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public List<ServiceEntity> Services { get; set; } = null!;
}