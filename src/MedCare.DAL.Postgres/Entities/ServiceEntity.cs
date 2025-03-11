namespace MedCare.DAL.Entities;

/// <summary>
/// Услуга
/// </summary>
public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public decimal? Price { get; set; } // check > 0

    /// <summary>
    /// Специализация, к которой относится данная услуга
    /// </summary>
    public SpecializationEntity Specialization { get; set; } = null!;
    public Guid SpecializationId { get; set; }
    
    /// <summary>
    /// Запись на прием, на котором оказывается эта услуга
    /// </summary>
    public AppointmentEntity Appointment { get; set; } = null!;
    
    /// <summary>
    /// Филиалы, в которых может оказываться данная услуга
    /// </summary>
    public List<BranchEntity> Branches { get; set; } = [];
}