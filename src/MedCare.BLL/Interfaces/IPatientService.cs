using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Interfaces;

public interface IPatientService
{
    public Task<UserModel> GetByIdAsync(Guid id);
    
    public Task<List<UserModel>> GetAllAsync();
}