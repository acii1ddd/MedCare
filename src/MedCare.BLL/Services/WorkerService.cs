using AutoMapper;
using MedCare.BLL.Exceptions;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

internal class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public WorkerService(IWorkerRepository workerRepository, IMapper mapper, IAppointmentRepository appointmentRepository)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
        _appointmentRepository = appointmentRepository;
    }

    public async Task<List<UserModel>> GetByBranchNameWithFilterAsync(string branchName, Guid? specializationId)
    {
        return _mapper.Map<List<UserModel>>(
            await _workerRepository.GetDoctorsByBranchNameWithFilterAsync(branchName, specializationId)
        );
    }

    public async Task<List<DateTime>> GetAvailableDaysForDoctorAsync(Guid doctorId, DateTime? startDate, DateTime? endDate)
    {
        // если null, то присвоить значения
        startDate ??= DateTime.Today;
        endDate ??= new DateTime(
            startDate.Value.Year, startDate.Value.Month,
            DateTime.DaysInMonth(startDate.Value.Year, startDate.Value.Month)
        );
        
        var doctor = _mapper.Map<UserModel>(await _workerRepository.GetByIdAsync(doctorId));
        
        if (doctor.Schedules == null)
            throw new InvalidOperationException($"У врача {doctor.Id} нет расписания");

        var availableDays = new List<DateTime>();
        
        // по дням до конца текущего месяца
        for (var currentDate = startDate.Value; currentDate <= endDate.Value; currentDate = currentDate.AddDays(1))
        {
            var freeSlots = await GetAvailableSlotsForDoctorAsync(doctor, currentDate);

            if (freeSlots.Count != 0)
            {
                availableDays.Add(currentDate);
            }
        }
        return availableDays;
    }

    private async Task<List<DateTime>> GetAvailableSlotsForDoctorAsync(UserModel doctor, DateTime visitDate)
    {
        var currentDayOfWeek = visitDate.DayOfWeek;
            
        // расписание этого дня недели
        var schedule = doctor.Schedules?.FirstOrDefault(x => x.DayOfWeek == currentDayOfWeek);
        if (schedule == null)
            return [];
            
        var allSlots = GetAllSlotsForDay(visitDate, schedule.StartTime, schedule.EndTime);
            
        // записи к этому врачу на этот день
        var appointments = _mapper.Map<List<AppointmentModel>>(
            await _appointmentRepository.GetAllWithFilterAsync(
                visitDate, null, null, null, doctor.Id)
        );
        var occupiedSlots = appointments
            .Select(
            x => TimeZoneInfo.ConvertTimeFromUtc(
                x.VisitDate,
                TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time")
            ))
            .ToList();
            
        // слоты из allSlots, которых нет в занятых
        var freeSlots = allSlots.Where(slot => !occupiedSlots.Contains(slot)).ToList();
        
        return freeSlots.Count != 0 ? freeSlots : [];
    }

    public async Task<UserModel> GetByIdAsync(Guid id)
    {
        return _mapper.Map<UserModel>(await _workerRepository.GetByIdAsync(id));
    }

    public async Task<List<DateTime>> GetAvailableSlotsForDoctor(Guid id, DateTime visitDate)
    {
        var doctor = _mapper.Map<UserModel>(await _workerRepository.GetByIdAsync(id))
            ?? throw new NotFoundException($"Врач с Id {id} не найден");
        
        return await GetAvailableSlotsForDoctorAsync(doctor, visitDate);
    }

    private static List<DateTime> GetAllSlotsForDay(DateTime date, TimeSpan startTime, TimeSpan endTime)
    {
        var slots = new List<DateTime>();
        var current = date.Date + startTime;
        var end = date.Date + endTime;
        
        // последний слот endTime - 15
        while (current < end) {
            slots.Add(current);
            current = current.AddMinutes(15);
        }
        return slots;
    }
}   