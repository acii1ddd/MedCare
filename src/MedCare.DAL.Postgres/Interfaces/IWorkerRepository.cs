using MedCare.DAL.Entities.Users;

namespace MedCare.DAL.Interfaces;
    
public interface IWorkerRepository
{
    public Task<List<WorkerEntity>> GetAllByBranchNameAsync(string filialName);
    
    public Task<WorkerEntity?> GetByIdAsync(int id);
    
    public Task<WorkerEntity> AddAsync(WorkerEntity worker);
    
    public Task<WorkerEntity> UpdateAsync(WorkerEntity worker);
    
    public Task<WorkerEntity> DeleteByIdAsync(int id);
}