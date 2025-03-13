using AutoMapper;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Mappers.Users;

public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<UserModel, UserEntity>().ReverseMap();
    }
}