using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class MedicalRecordProfile : Profile
{
    public MedicalRecordProfile()
    {
        CreateMap<MedicalRecordModel, MedicalRecordEntity>().ReverseMap();
    }
}