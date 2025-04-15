using AutoMapper;
using MedCare.BLL.Models.Users;

namespace MedCare.API.Contracts.Responses.Workers;

public class GetSmallDoctorResponse
{
    public Guid Id { get; init; }
    
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string Patronymic { get; init; } = string.Empty;
    
    public string SpecializationName { get; init; } = string.Empty;
}

public class GetSmallWorkerResponseProfile : Profile
{
    public GetSmallWorkerResponseProfile()
    {
        CreateMap<UserModel, GetSmallDoctorResponse>()
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.UserProfile.LastName))
            .ForMember(dest => dest.Patronymic, opt
                => opt.MapFrom(src => src.UserProfile.Patronymic))
            .ForMember(dest => dest.SpecializationName, opt
                => opt.MapFrom(src => src.Specialization!.Name));
    }
}