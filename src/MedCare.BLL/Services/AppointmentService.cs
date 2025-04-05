using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }

    public async Task<AppointmentModel> AddAsync(AppointmentModel appointment)
    {
        return _mapper.Map<AppointmentModel>(
            await _appointmentRepository.AddAsync(_mapper.Map<AppointmentEntity>(appointment))
        );
    }
}