using MedCare.BLL.Models;

namespace MedCare.BLL.Services;

public interface IAppointmentService
{
    public Task<AppointmentModel> AddAsync(AppointmentModel appointment);
}