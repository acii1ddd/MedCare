using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;
    
public interface IWorkerRepository
{
    public Task<List<UserEntity>> GetAllByBranchNameAsync(string filialName);
    
    public Task<UserEntity?> GetByIdAsync(int id);
    
    public Task<UserEntity> AddAsync(UserEntity user);
    
    public Task<UserEntity> UpdateAsync(UserEntity user);
    
    public Task<UserEntity> DeleteByIdAsync(int id);
}