using MedCare.DAL.Context;
using MedCare.DAL.Entities;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;

    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<BranchEntity>> GetAllAsync()
    {
        return await _context.Branches
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Получение специализаций определенного филиала
    /// </summary>
    /// <param name="branchId"></param>
    public async Task<List<SpecializationEntity>> GetSpecializationsByBranchAsync(Guid branchId)
    {
        return await _context.Branches
            .Where(x => x.Id == branchId)
            .SelectMany(x => x.Services)    
            .Select(x => x.Specialization)
            .Distinct()
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Получение услуг, определенной специализации для определенного филиала
    /// </summary>
    /// <param name="specializationId"></param>
    /// <param name="branchId"></param>
    public async Task<List<ServiceEntity>> GetServicesBySpecializationForBranchAsync(Guid specializationId, Guid branchId)
    {
        return await _context.Branches
            .Where(x => x.Id == branchId)
            .SelectMany(x => x.Services)
            .Where(x => x.SpecializationId == specializationId)
            .AsNoTracking()
            .ToListAsync();
    }
}