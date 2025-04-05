using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;
    
public interface IWorkerRepository
{
    public Task<UserEntity?> GetByIdAsync(Guid id);
    
    public Task<UserEntity> AddAsync(UserEntity user);
    
    public Task<UserEntity> UpdateAsync(UserEntity user);
    
    public Task<UserEntity> DeleteByIdAsync(int id);
    
    public Task<List<UserEntity>> GetDoctorsByBranchNameWithFilterAsync(string branchName, Guid? specializationId);
    
    // public Task<List<UserEntity>> GetAvailableDaysForDoctorAsync(Guid doctorId);
}