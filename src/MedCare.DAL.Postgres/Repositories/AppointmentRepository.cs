using MedCare.DAL.Context;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCare.DAL.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly ApplicationDbContext _context;

    public AppointmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AppointmentEntity> AddAsync(AppointmentEntity appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task<List<AppointmentEntity>> GetAllWithFilterAsync(Guid? doctorId, DateTime? visitDate)
    {
        var appointments = _context.Appointments
            .AsNoTracking();

        if (doctorId.HasValue)
        {
            appointments = appointments.Where(x => x.DoctorId == doctorId);
        }
        if (visitDate.HasValue)
        {
            visitDate = visitDate.Value.ToUniversalTime();
            appointments = appointments.Where(x => x.VisitDate == visitDate);
        }
        
        return await appointments.ToListAsync();
    }
}