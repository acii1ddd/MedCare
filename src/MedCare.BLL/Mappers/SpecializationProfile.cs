using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class SpecializationProfile : Profile
{
    public SpecializationProfile()
    {
        CreateMap<SpecializationModel, SpecializationEntity>().ReverseMap();
    }
}