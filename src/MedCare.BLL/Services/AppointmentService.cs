using System.Text;
using AutoMapper;
using MedCare.BLL.Exceptions;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.DAL.Entities.Appointments;
using MedCare.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace MedCare.BLL.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AppointmentModel> _logger;
    
    public AppointmentService(
        IAppointmentRepository appointmentRepository, 
        IMapper mapper, 
        IUserRepository userRepository, 
        ILogger<AppointmentModel> logger, 
        IServiceRepository serviceRepository)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _logger = logger;
        _serviceRepository = serviceRepository;
    }

    public async Task<AppointmentModel> AddAsync(AppointmentModel appointment, Guid patientId)
    {
        if (await _userRepository.GetByIdAsync(patientId) is null)
        {
            throw new NotFoundException($"Пациент с Id {patientId} не найден");
        }
        
        if (appointment.DoctorId is null)
        {
            _logger.LogWarning("Врач отсутствует в объекте записи на прием");
        }
        else if (await _userRepository.GetByIdAsync(appointment.DoctorId.Value) is null)
        {
            throw new NotFoundException($"Врач с Id {appointment.DoctorId} не найден");
        }

        if (await _serviceRepository.GetByIdAsync(appointment.ServiceId) is null)
        {
            throw new NotFoundException($"Услуга с Id {appointment.ServiceId} не найдена");
        }

        appointment.Id = Guid.NewGuid();

        appointment.VisitDate = appointment.VisitDate.Kind != DateTimeKind.Utc
            ? appointment.VisitDate.ToUniversalTime()
            : appointment.VisitDate;
        
        appointment.PatientId = patientId;
        return _mapper.Map<AppointmentModel>(
            await _appointmentRepository.AddAsync(_mapper.Map<AppointmentEntity>(appointment))
        );
    }

    public async Task<List<AppointmentModel>> GetAllWithFilterAsync(DateTime? visitDate, 
        AppointmentStatus? appointmentStatus, PaymentStatus? paymentStatus, Guid? patientId, Guid? doctorId)
    {
        return _mapper.Map<List<AppointmentModel>>(await _appointmentRepository
            .GetAllWithFilterAsync(visitDate, appointmentStatus, paymentStatus, patientId, doctorId)
        );
    }

    public async Task SetToCompletedAsync(Guid appointmentId)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(appointmentId);
        if (appointment is null)
        {
            throw new NotFoundException($"Запись с Id {appointmentId} не найдена");
        }
        
        appointment.AppointmentStatus = AppointmentStatus.Completed;
        await _appointmentRepository.Update(_mapper.Map<AppointmentEntity>(appointment));
    }
}