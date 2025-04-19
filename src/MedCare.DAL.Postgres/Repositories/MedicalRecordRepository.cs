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

    public async Task<List<MedicalRecordEntity>> GetAllByPatientAsync(Guid patientId)
    {
        return await _context.MedicalRecords
            .Where(x => x.Appointment.PatientId == patientId)
            .Include(x => x.Appointment)
                .ThenInclude(x => x.Doctor)
                    .ThenInclude(x => x!.UserProfile)
            .Include(x => x.Appointment)
                .ThenInclude(x => x.Doctor)
                    .ThenInclude(x => x!.Specialization)
            .Include(x => x.Appointment)
                .ThenInclude(x => x.Patient)
                    .ThenInclude(x => x.UserProfile)
            .Include(x => x.Appointment)
                .ThenInclude(x => x.Service)
            .AsNoTracking()
            .ToListAsync();
    }
}