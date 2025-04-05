using MedCare.DAL.Context;
using MedCare.DAL.Entities.Users;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class WorkerRepository : IWorkerRepository
{
    private readonly ApplicationDbContext _context;

    public WorkerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Include(x => x.Specialization)
            .Include(x => x.Branch)
            .Include(x => x.Schedules)
            .Where(x => x.UserRole == UserRole.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<UserEntity> AddAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> UpdateAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserEntity>> GetDoctorsByBranchNameWithFilterAsync(string branchName, Guid? specializationId)
    {
        var doctors = _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Include(x => x.Specialization)
            .Include(x => x.Branch)
            .Where(x => x.UserRole == UserRole.Doctor)
            .Where(x => x.Branch != null && x.Branch.Name == branchName);
        
        if (specializationId.HasValue)
        {
            doctors = doctors.Where(x => x.Specialization!.Id == specializationId);
        }
        return await doctors.ToListAsync();
    }

    // public Task<List<UserEntity>> GetAvailableDaysForDoctorAsync(Guid doctorId)
    // {
    //     
    // }
}