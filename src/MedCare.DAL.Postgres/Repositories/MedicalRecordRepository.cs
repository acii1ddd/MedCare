using MedCare.DAL.Context;
using MedCare.DAL.Entities;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class MedicalRecordRepository : IMedicalRecordRepository
{
    private readonly ApplicationDbContext _context;

    public MedicalRecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<MedicalRecordEntity> AddAsync(MedicalRecordEntity medicalRecord)
    {
        await _context.MedicalRecords.AddAsync(medicalRecord);
        await _context.SaveChangesAsync();
        return medicalRecord;
    }

    public async Task<List<MedicalRecordEntity>> GetAllAsync()
    {
        return await _context.MedicalRecords
            .AsNoTracking()
            .ToListAsync();
    }
}