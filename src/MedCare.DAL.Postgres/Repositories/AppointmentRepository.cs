using MedCare.DAL.Context;
using MedCare.DAL.Dto;
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
            var localStart = DateTime.SpecifyKind(visitDate.Value.Date, DateTimeKind.Unspecified);
            var dayEnd = localStart.AddDays(1);
            
            var utcStart = localStart.ToUniversalTime();
            var utcEnd = dayEnd.ToUniversalTime();
            
            appointments = appointments.Where(x => x.VisitDate >= utcStart && x.VisitDate < utcEnd);
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

    public async Task Update(AppointmentEntity appointment)
    {
        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<AppointmentEntity?> GetByIdAsync(Guid id)
    {
        return await _context.Appointments.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<PopularSpecializationDto>> GetPopularSpecializationsAsync()
    {
        return await _context.Appointments
            .Where(a=> a.PaymentStatus == PaymentStatus.Paid)
            .GroupBy(a => new {
                a.Doctor!.SpecializationId,
                a.Doctor!.Specialization!.Name
            })
            .Select(g => new PopularSpecializationDto {
                SpecializationId = g.Key.SpecializationId!.Value,
                SpecializationName = g.Key.Name,
                AppointmentCount = g.Count()
            })
            .OrderByDescending(g => g.AppointmentCount)
            .ToListAsync();
    }
    
    public async Task<List<PopularDoctorsDto>> GetPopularDoctorsAsync()
    {
        return await _context.Appointments
            .Where(a => a.DoctorId != null && a.PaymentStatus == PaymentStatus.Paid)
            .GroupBy(u => new {
                u.Doctor!.Id,
                u.Doctor!.UserProfile.FirstName,
                u.Doctor!.UserProfile.LastName,
                u.Doctor!.UserProfile.Patronymic,
                u.Doctor!.Specialization!.Name,
            })
            .Select(g => new PopularDoctorsDto {
                DoctorId = g.Key.Id,
                SpecializationName = g.Key.Name,
                DoctorName = $"{g.Key.FirstName} {g.Key.LastName} {g.Key.Patronymic}",
                AppointmentCount = g.Count()
            })
            .OrderByDescending(g => g.AppointmentCount)
            .ToListAsync();
    }
    
    public async Task<List<PopularServicesDto>> GetPopularServicesAsync()
    {
        return await _context.Appointments
            .Where(a => a.DoctorId != null && a.PaymentStatus == PaymentStatus.Paid)
            .GroupBy(u => new {
                u.Service.Id,
                u.Service.Name
            })
            .Select(g => new PopularServicesDto {
                ServiceId = g.Key.Id,
                ServiceName = g.Key.Name,
                AppointmentCount = g.Count()
            })
            .OrderByDescending(g => g.AppointmentCount)
            .ToListAsync();
    }
}
