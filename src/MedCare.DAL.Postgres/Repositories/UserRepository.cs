using MedCare.DAL.Context;
using MedCare.DAL.Entities.Users;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetByLoginAsync(string login)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Login == login);
    }

    public async Task<UserEntity?> GetByIdAsync(Guid userId)
    {
        return await _context.Users
            .Include(x => x.UserProfile)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<List<UserEntity>> GetAllWorkersAsync()
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Include(x => x.Specialization)
            .Include(x => x.Branch)
                .ThenInclude(x => x!.Address)
                    .ThenInclude(x => x.City)
            .Include(x => x.Schedules)
            .Where(x => x.UserRole != UserRole.Patient)
            .ToListAsync();
    }

    public async Task<UserEntity?> GetDoctorByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Include(x => x.Specialization)
            .Include(x => x.Branch)
                .ThenInclude(x => x!.Address)
                    .ThenInclude(x => x!.City)
            .Include(x => x.Schedules)
            .Where(x => x.UserRole == UserRole.Doctor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserEntity?> GetPatientByIdAsync(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Where(x => x.UserRole == UserRole.Patient)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<UserEntity>> GetAllPatientsAsync()
    {
         return await _context.Users
            .AsNoTracking()
            .Include(x => x.UserProfile)
            .Where(x => x.UserRole == UserRole.Patient)
            .ToListAsync();
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
}