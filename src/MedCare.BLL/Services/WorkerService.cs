using System.Runtime.InteropServices;
using AutoMapper;
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
        if (!startDate.HasValue)
        {
            startDate = DateTime.Today;
        }
        if (!endDate.HasValue)
        {
            endDate = new DateTime(
                startDate.Value.Year, startDate.Value.Month, 
                DateTime.DaysInMonth(startDate.Value.Year, startDate.Value.Month)
            );
        }
        
        var doctor = _mapper.Map<UserModel>(await _workerRepository.GetByIdAsync(doctorId));
        
        if (doctor.Schedules == null) 
            throw new InvalidOperationException("Schedules cannot be null.");

        var availableDays =  new List<DateTime>();
        
        // по дням до конца текущего месяца
        for (var currentDate = startDate.Value; currentDate <= endDate.Value; currentDate = currentDate.AddDays(1))
        {
            var currentDayOfWeek = currentDate.DayOfWeek;
            
            // расписание этого дня недели
            var schedule = doctor.Schedules.FirstOrDefault(x => x.DayOfWeek == currentDayOfWeek);
            if (schedule == null)
                continue;
            
            var allSlots = GetAllSlotsForDay(currentDate, schedule.StartTime, schedule.EndTime);
            
            // записи к этому врачу на этот день
            var appointments = _mapper.Map<List<AppointmentModel>>(
                await _appointmentRepository.GetAllWithFilterAsync(doctorId, currentDate)
            );
            var occupiedSlots = appointments.Select(x => x.VisitDate).ToList();
            
            // слоты из allSlots, которых нет в занятых
            var freeSlots = allSlots.Where(slot => !occupiedSlots.Contains(slot)).ToList();
            if (freeSlots.Count != 0)
            {
                availableDays.Add(currentDate);
            }
        }
        return availableDays;
    }

    public async Task<UserModel> GetByIdAsync(Guid id)
    {
        return _mapper.Map<UserModel>(await _workerRepository.GetByIdAsync(id));
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