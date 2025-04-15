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

    public async Task<List<AppointmentEntity>> GetAllWithFilterAsync(DateTime? visitDate, 
        AppointmentStatus? appointmentStatus, PaymentStatus? paymentStatus, Guid? patientId, Guid? doctorId)
    {
        var appointments = _context.Appointments.AsNoTracking();

        if (visitDate.HasValue)
        {
            visitDate = visitDate.Value.ToUniversalTime();
            appointments = appointments.Where(x => x.VisitDate == visitDate);
        }
        if (appointmentStatus != null)
        {
            appointments = appointments.Where(x => x.AppointmentStatus == appointmentStatus);
        }
        if (paymentStatus != null)
        {
            appointments = appointments.Where(x => x.PaymentStatus == paymentStatus);
        }
        if (patientId.HasValue)
        {
            appointments = appointments.Where(x => x.PatientId == patientId);
        }
        if (doctorId.HasValue)
        {
            appointments = appointments.Where(x => x.DoctorId == doctorId);
        }
        
        return await appointments
            .Include(x => x.MedicalRecords)
            .Include(x => x.Doctor)
                .ThenInclude(x => x!.UserProfile)
            .Include(x => x.Doctor)
                .ThenInclude(x => x!.Specialization)
            .Include(x => x.Patient)
                .ThenInclude(x => x.UserProfile)
            .Include(x => x.Service)
            .ToListAsync();
    }
}