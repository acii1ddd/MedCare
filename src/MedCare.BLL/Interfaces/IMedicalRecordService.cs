using MedCare.BLL.Models;

namespace MedCare.BLL.Interfaces;

public interface IMedicalRecordService
{
    public Task<MedicalRecordModel> AddAsync(MedicalRecordModel medicalRecord);
    
    public Task<List<MedicalRecordModel>> GetAllByPatientAsync(Guid patientId);
}