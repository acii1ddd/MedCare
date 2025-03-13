using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityModel, CityEntity>().ReverseMap();
    }
}