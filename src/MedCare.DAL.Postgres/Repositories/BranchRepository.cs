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
}