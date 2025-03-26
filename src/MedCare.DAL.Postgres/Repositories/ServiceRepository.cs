// using MedCare.DAL.Context;
// using MedCare.DAL.Entities;
// using MedCare.DAL.Interfaces;
// using Microsoft.EntityFrameworkCore;
//
// namespace MedCare.DAL.Repositories;
//
// public class ServiceRepository : IServiceRepository
// {
//     private readonly ApplicationDbContext _context;
//
//     public ServiceRepository(ApplicationDbContext context)
//     {
//         _context = context;
//     }
//     /// <summary>
//     /// Получение услуг, определенной специализации для определенного филиала
//     /// </summary>
//     /// <param name="specializationId"></param>
//     /// <param name="branchId"></param>
//     public async Task<List<ServiceEntity>> GetBySpecializationForBranchAsync(Guid specializationId, Guid branchId)
//     {
//         return await _context.Branches
//             .Where(x => x.Id == branchId)
//             .SelectMany(x => x.Services)
//             .Where(x => x.SpecializationId == specializationId)
//             .AsNoTracking()
//             .ToListAsync();
//     }
// }