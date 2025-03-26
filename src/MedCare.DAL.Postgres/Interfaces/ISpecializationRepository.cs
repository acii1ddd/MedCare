using MedCare.DAL.Entities;

namespace MedCare.DAL.Interfaces;

public interface ISpecializationRepository
{
    public Task<List<SpecializationEntity>> GetByBranchAsync(Guid branchId);
}