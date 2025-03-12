using MedCare.Common.Models.Users;
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

    public async Task<List<WorkerEntity>> GetAllByBranchNameAsync(string branchName)
    {
        return await _context.Workers.AsNoTracking()
            .Where(x => x.UserRole == UserRole.Doctor)
            .Where(x => x.Branch.Name == branchName)
            .ToListAsync();
    }

    public Task<WorkerEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<WorkerEntity> AddAsync(WorkerEntity worker)
    {
        throw new NotImplementedException();
    }

    public Task<WorkerEntity> UpdateAsync(WorkerEntity worker)
    {
        throw new NotImplementedException();
    }

    public Task<WorkerEntity> DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}