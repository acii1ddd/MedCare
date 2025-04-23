using MedCare.BLL.Models;
using MedCare.DAL.Dto;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.BLL.Interfaces;

public interface IAppointmentService
{
    public Task<AppointmentModel> AddAsync(AppointmentModel appointment, Guid patientId);

    public Task<List<AppointmentModel>> GetAllWithFilterAsync(DateTime? visitDate,
        AppointmentStatus? appointmentStatus, PaymentStatus? paymentStatus, Guid? patientId, Guid? doctorId);

    public Task SetToCompletedAsync(Guid appointmentId);
    
    public Task MarkAsPaid(Guid appointmentId);

    public Task<List<PopularSpecializationDto>> GetPopularSpecializationsAsync();

    public Task<List<PopularDoctorsDto>> GetPopularDoctorsAsync();
    
    public Task<List<PopularServicesDto>> GetPopularServicesAsync();
}