using MedCare.DAL.Entities;

namespace MedCare.DAL.Interfaces;

public interface IBranchRepository
{
    public Task<List<BranchEntity>> GetAllAsync();
}