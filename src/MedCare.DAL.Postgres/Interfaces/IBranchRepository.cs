using MedCare.DAL.Entities;

namespace MedCare.DAL.Interfaces;

public interface IBranchRepository
{
    public Task<List<BranchEntity>> GetAllAsync();
    
    public Task<List<SpecializationEntity>> GetSpecializationsByBranchAsync(Guid branchId);

    public Task<List<ServiceEntity>> GetServicesBySpecializationForBranchAsync(Guid specializationId, Guid branchId);
}