using AutoMapper;
using MedCare.BLL.Exceptions;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;
using MedCare.DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace MedCare.BLL.Services;

internal class WorkerService : IWorkerService
{
    private readonly IUserRepository _userRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IPasswordHashService _passwordHashService;
    private readonly IMapper _mapper;

    public WorkerService(IUserRepository userRepository, IMapper mapper, IAppointmentRepository appointmentRepository, IPasswordHashService passwordHashService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _appointmentRepository = appointmentRepository;
        _passwordHashService = passwordHashService;
    }

    public async Task<List<UserModel>> GetByBranchNameWithFilterAsync(string branchName, Guid? specializationId)
    {
        return _mapper.Map<List<UserModel>>(
            await _userRepository.GetDoctorsByBranchNameWithFilterAsync(branchName, specializationId)
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
        
        var doctor = _mapper.Map<UserModel>(await _userRepository.GetDoctorByIdAsync(doctorId));
        
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

    public async Task<UserModel> GetDoctorByIdAsync(Guid id)
    {
        var doctor = await _userRepository.GetDoctorByIdAsync(id);
        if (doctor is null)
        {
            throw new NotFoundException($"Врач с Id {id} не найден");
        }
        
        return _mapper.Map<UserModel>(doctor);
    }

    public async Task<List<DateTime>> GetAvailableSlotsForDoctor(Guid id, DateTime visitDate)
    {
        var doctor = _mapper.Map<UserModel>(await _userRepository.GetDoctorByIdAsync(id))
            ?? throw new NotFoundException($"Врач с Id {id} не найден");
        
        return await GetAvailableSlotsForDoctorAsync(doctor, visitDate);
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return  _mapper.Map<List<UserModel>>(await _userRepository.GetAllWorkersAsync());
    }

    public async Task DeleteAsync(Guid workerId)
    {
        var worker = await _userRepository.GetByIdAsync(workerId);
        if (worker is null)
        {
            throw new NotFoundException("Сотрудник с Id не найден");
        }
        if (worker.UserRole == UserRole.Director)
        {
            throw new InvalidOperationException("Невозможно удалить директора");
        }
        await _userRepository.DeleteAsync(worker);
    }

    public async Task AddAsync(UserModel user, IFormFile? image)
    {
        if (user.UserProfile.BirthDate.Kind != DateTimeKind.Utc)
        {
            throw new InvalidOperationException("BirthDate должна быть в формате Utc");
        }
        
        user.Id = Guid.NewGuid();
        user.PasswordHash = _passwordHashService.HashPassword(user.PasswordHash);
        
        var profileId = Guid.NewGuid();
        user.UserProfile.Id = profileId;
        user.UserProfileId = profileId;

        if (image != null)
        {
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            user.UserProfile.Image = stream.ToArray();
        }
        
        await _userRepository.AddAsync(_mapper.Map<UserEntity>(user));
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