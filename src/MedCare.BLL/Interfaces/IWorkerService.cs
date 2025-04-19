using MedCare.BLL.Models.Users;

namespace MedCare.BLL.Interfaces;

public interface IWorkerService
{
    public Task<List<UserModel>> GetByBranchNameWithFilterAsync(string branchName, Guid? specializationId);
    
    public Task<List<DateTime>> GetAvailableDaysForDoctorAsync(Guid doctorId, DateTime? startDate, DateTime? endDate);
    
    public Task<UserModel> GetDoctorByIdAsync(Guid id);
    
    public Task<List<DateTime>> GetAvailableSlotsForDoctor(Guid id, DateTime visitDate);
}