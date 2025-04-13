using MedCare.DAL.Entities;

namespace MedCare.DAL.Interfaces;

public interface IServiceRepository
{
    public Task<List<ServiceEntity>> GetByBranchWithFilterAsync(Guid branchId, Guid specializationId);
}