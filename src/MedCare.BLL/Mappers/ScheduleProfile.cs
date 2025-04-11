using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;

namespace MedCare.BLL.Mappers;

public class ScheduleProfile : Profile
{
    public ScheduleProfile()
    {
        CreateMap<ScheduleModel, ScheduleEntity>().ReverseMap();
    }
}
