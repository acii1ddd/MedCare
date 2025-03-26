using MedCare.BLL.Models;

namespace MedCare.BLL.Interfaces;

public interface IBranchService
{
    public Task<List<BranchModel>> GetAllAsync();
}