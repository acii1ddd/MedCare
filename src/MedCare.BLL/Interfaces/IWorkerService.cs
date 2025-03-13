using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Interfaces;

public interface IWorkerService
{
    public Task<List<UserModel>> GetAllByBranchNameAsync(string branchName);
}