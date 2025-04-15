using MedCare.DAL.Entities.Appointments;

namespace MedCare.DAL.Interfaces;

public interface IAppointmentRepository
{
    public Task<AppointmentEntity> AddAsync(AppointmentEntity appointment);

    public Task<List<AppointmentEntity>> GetAllWithFilterAsync(DateTime? visitDate,
        AppointmentStatus? appointmentStatus, PaymentStatus? paymentStatus, Guid? patientId, Guid? doctorId);
}