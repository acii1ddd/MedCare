using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<ServiceModel, ServiceEntity>().ReverseMap();
    }
}