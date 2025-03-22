using MedCare.BLL.Models;

namespace MedCare.BLL.Interfaces;

public interface IBranchService
{
    public Task<List<BranchModel>> GetAllAsync();
    
    public Task<List<SpecializationModel>> GetByBranchAsync(Guid branchId);
    
    public Task<List<ServiceModel>> GetServicesBySpecializationForBranch(Guid specializationId, Guid branchId);
}