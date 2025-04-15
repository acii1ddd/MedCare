using MedCare.DAL.Entities;

namespace MedCare.DAL.Interfaces;

public interface IMedicalRecordRepository
{
    public Task<MedicalRecordEntity> AddAsync(MedicalRecordEntity medicalRecord);
    
    public Task<List<MedicalRecordEntity>> GetAllAsync();
}