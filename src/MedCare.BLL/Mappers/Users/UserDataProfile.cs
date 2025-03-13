using AutoMapper;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.BLL.Mappers.Users;

public class UserDataProfile : Profile
{
    public UserDataProfile()
    {
        CreateMap<UserProfileModel, UserProfileEntity>().ReverseMap();
    }
}