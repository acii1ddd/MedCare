using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;

public interface IUserRepository
{
    // workers
    public Task<UserEntity?> GetByLoginAsync(string login);
    
    public Task<UserEntity?> GetByIdAsync(Guid userId);
    
    public Task<List<UserEntity>> GetAllWorkersAsync();
    
    public Task DeleteAsync(UserEntity user);
    
    public Task AddAsync(UserEntity user);
    
    // doctors
    public Task<UserEntity?> GetDoctorByIdAsync(Guid id);

    public Task<List<UserEntity>> GetDoctorsByBranchNameWithFilterAsync(string branchName, Guid? specializationId);
    

    // patients
    public Task<UserEntity?> GetPatientByIdAsync(Guid id);
    
    public Task<List<UserEntity>> GetAllPatientsAsync();
}