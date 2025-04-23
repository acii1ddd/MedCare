using MedCare.DAL.Dto;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Repositories;

namespace MedCare.DAL.Interfaces;

public interface IAppointmentRepository
{
    public Task<AppointmentEntity> AddAsync(AppointmentEntity appointment);

    public Task<List<AppointmentEntity>> GetAllWithFilterAsync(DateTime? visitDate,
        AppointmentStatus? appointmentStatus, PaymentStatus? paymentStatus, Guid? patientId, Guid? doctorId);

    public Task Update(AppointmentEntity appointment);
    
    public Task<AppointmentEntity?> GetByIdAsync(Guid id);

    public Task<List<PopularSpecializationDto>> GetPopularSpecializationsAsync();

    public Task<List<PopularDoctorsDto>> GetPopularDoctorsAsync();

    public Task<List<PopularServicesDto>> GetPopularServicesAsync();
}