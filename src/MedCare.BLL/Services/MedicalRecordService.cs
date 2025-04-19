using AutoMapper;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IMedicalRecordRepository _medicalRecordRepository; 
    private readonly IMapper _mapper;

    public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMapper mapper)
    {
        _medicalRecordRepository = medicalRecordRepository;
        _mapper = mapper;
    }

    public async Task<MedicalRecordModel> AddAsync(MedicalRecordModel medicalRecord)
    {
        return _mapper.Map<MedicalRecordModel>(await _medicalRecordRepository
            .AddAsync(_mapper.Map<MedicalRecordEntity>(medicalRecord))
        );
    }

    public async Task<List<MedicalRecordModel>> GetAllByPatientAsync(Guid patientId)
    {
        return _mapper.Map<List<MedicalRecordModel>>(
            await _medicalRecordRepository.GetAllByPatientAsync(patientId)
        );
    }
}