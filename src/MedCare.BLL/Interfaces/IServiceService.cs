using MedCare.BLL.Models;

namespace MedCare.BLL.Interfaces;

public interface IServiceService
{
    public Task<List<ServiceModel>> GetByBranchNameAsync(string branchName);
}