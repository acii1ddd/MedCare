using AutoMapper;
using MedCare.BLL.Models;
using MedCare.DAL.Entities;
using MedCare.DAL.Entities.Appointments;

namespace MedCare.BLL.Mappers;

public class AppointmentProfile : Profile
{
    public AppointmentProfile()
    {
        CreateMap<AppointmentModel, AppointmentEntity>().ReverseMap();
    }
}