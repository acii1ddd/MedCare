using MedCare.DAL.Context;
using MedCare.DAL.Entities;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class SpecializationRepository : ISpecializationRepository
{
    private readonly ApplicationDbContext _context;

    public SpecializationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Получение специализаций со списком связным списком услуг для определенного филиала
    /// </summary>
    /// <param name="branchId"></param>
    public async Task<List<SpecializationEntity>> GetByBranchAsync(Guid branchId)
    {
        return await _context.Specializations
            .Where(x => x.Services
                .Any(s => s.Branches // чтобы взять специализацию для филиала нужно,
                                                // чтобы была хотя бы одна услуга, которая предоставляется в данном филиале 
                    .Any(b => b.Id == branchId)))
            .Include(x => x.Services)
            .Select(x => new SpecializationEntity
            {
                Id = x.Id,
                Name = x.Name,
                // берем только услуги, которые предоставляются в данном филиале
                Services = x.Services
                    .Where(s => s.Branches.Any(b => b.Id == branchId))
                    .ToList(),
                Workers = x.Workers
            })
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
