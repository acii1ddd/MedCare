using MedCare.DAL.Context;
using MedCare.DAL.Entities;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Получение услуг для определенного филиала с фильтрацией (по специализации)
    /// </summary>
    public async Task<List<ServiceEntity>> GetByBranchWithFilterAsync(Guid branchId, Guid specializationId)
    {
        return await _context.Branches
            .Where(x => x.Id == branchId)
            .SelectMany(x => x.Services)
            .Where(x => x.SpecializationId == specializationId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ServiceEntity?> GetByIdAsync(Guid serviceId)
    {
        return await _context.Services
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == serviceId);
    }
}