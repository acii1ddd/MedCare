using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;

public interface IUserRepository
{
    public Task<UserEntity?> GetByLoginAsync(string login);
    
    public Task<UserEntity?> GetByIdAsync(Guid userId);
    
    
    public Task<UserEntity?> GetDoctorByIdAsync(Guid id);

    public Task<List<UserEntity>> GetDoctorsByBranchNameWithFilterAsync(string branchName, Guid? specializationId);
    
    
    public Task<UserEntity?> GetPatientByIdAsync(Guid id);
    
    public Task<List<UserEntity>> GetAllPatientsAsync();
}