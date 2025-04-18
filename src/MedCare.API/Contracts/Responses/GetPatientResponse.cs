using AutoMapper;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.API.Contracts.Responses;

public class GetPatientResponse
{
    public Guid Id { get; set; }
    
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string Patronymic { get; init; } = string.Empty;
    
    public DateTime BirthDate { get; init; }
    
    public Gender Gender { get; init; }
    
    public string Email { get; init; } = string.Empty;
    
    public string PhoneNumber { get; init; } = string.Empty;
}

public class GetPatientResponseProfile : Profile
{
    public GetPatientResponseProfile()
    {
        CreateMap<UserModel, GetPatientResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.UserProfile.LastName))
            .ForMember(dest => dest.Patronymic, opt
                => opt.MapFrom(src => src.UserProfile.Patronymic))
            .ForMember(dest => dest.BirthDate, opt
                => opt.MapFrom(src => src.UserProfile.BirthDate))
            .ForMember(dest => dest.Gender, opt
                => opt.MapFrom(src => src.UserProfile.Gender))
            .ForMember(dest => dest.Email, opt
                => opt.MapFrom(src => src.UserProfile.Email))
            .ForMember(dest => dest.PhoneNumber, opt
                => opt.MapFrom(src => src.UserProfile.PhoneNumber));
    }
}