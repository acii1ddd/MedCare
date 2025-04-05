using MedCare.DAL.Entities.Appointments;

namespace MedCare.DAL.Interfaces;

public interface IAppointmentRepository
{
    public Task<AppointmentEntity> AddAsync(AppointmentEntity appointment);

    public Task<List<AppointmentEntity>> GetAllWithFilterAsync(Guid? doctorId, DateTime? visitDate);
}