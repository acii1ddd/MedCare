using AutoMapper;
using MedCare.Common.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Mappers;

public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<WorkerModel, WorkerEntity>().ReverseMap();
    }
}