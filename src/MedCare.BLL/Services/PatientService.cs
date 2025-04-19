using AutoMapper;
using MedCare.BLL.Exceptions;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

public class PatientService : IPatientService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public PatientService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserModel> GetByIdAsync(Guid id)
    {
        var patient = await _userRepository.GetPatientByIdAsync(id);
        if (patient is null)
        {
            throw new NotFoundException($"Пациент с Id {id} не найден");
        }
        
        return _mapper.Map<UserModel>(patient);
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return _mapper.Map<List<UserModel>>(
            await _userRepository.GetAllPatientsAsync()
        );
    }
}