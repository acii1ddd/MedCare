using MedCare.Common.Models.Users;

namespace MedCare.BLL.Interfaces;

public interface IWorkerService
{
    public Task<List<WorkerModel>> GetAllByBranchNameAsync(string branchName);
}