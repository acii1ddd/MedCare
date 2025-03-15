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

    public async Task<List<UserEntity>> GetAllByBranchNameAsync(string branchName)
    {
        return await _context.Users.AsNoTracking()
            .Where(x => x.UserRole == UserRole.Doctor)
            .Where(x => x.Branch != null && x.Branch.Name == branchName)
            .Include(x => x.UserProfile)
            .Include(x => x.Specialization)
            .Include(x => x.Branch)
            .ToListAsync();
    }

    public Task<UserEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
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
}