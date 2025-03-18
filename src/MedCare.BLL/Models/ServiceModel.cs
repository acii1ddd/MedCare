namespace MedCare.BLL.Models;

public class ServiceModel : BaseModel
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    /// <summary>
    /// Специализация, к которой относится данная услуга
    /// </summary>
    public SpecializationModel Specialization { get; set; } = null!;
    public Guid SpecializationId { get; set; }
    
    /// <summary>
    /// Записи на прием, на которых оказывается эта услуга
    /// </summary>
    public List<AppointmentModel> Appointments { get; set; } = [];
    
    /// <summary>
    /// Филиалы, в которых может оказываться данная услуга
    /// </summary>
    public List<BranchModel> Branches { get; set; } = [];
}