using AutoMapper;
using MedCare.API.Contracts.Responses.Branches;
using MedCare.API.Contracts.Responses.Schedules;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.API.Contracts.Responses.Workers;

public class GetWorkerResponse
{
    public Guid Id { get; init; }
    
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string Patronymic { get; init; } = string.Empty;
    
    public DateTime BirthDate { get; init; }
    
    public Gender Gender { get; init; }
    
    public string Email { get; init; } = string.Empty;
    
    public string PhoneNumber { get; init; } = string.Empty;
    
    public byte[] Image { get; init; } = [];
    
    public string PassportNumber { get; init; } = string.Empty;
    
    public string PassportSeries { get; init; } = string.Empty;
    
    public string Role { get; init; } = string.Empty;

    public string SpecializationName { get; init; } = string.Empty;
    
    public GetBranchResponse Branch { get; init; } = null!;
    
    public List<GetScheduleResponse> Schedules { get; init; } = [];
}

public class GetWorkerResponseProfile : Profile
{
    public GetWorkerResponseProfile()
    {
        CreateMap<UserModel, GetWorkerResponse>()
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
                => opt.MapFrom(src => src.UserProfile.PhoneNumber))
            .ForMember(dest => dest.Image, opt
                => opt.MapFrom(src => src.UserProfile.Image))
            .ForMember(dest => dest.PassportNumber, opt
                => opt.MapFrom(src => src.UserProfile.PassportNumber))
            .ForMember(dest => dest.PassportSeries, opt
                => opt.MapFrom(src => src.UserProfile.PassportSeries))
            .ForMember(dest => dest.Role, opt
                => opt.MapFrom(src => src.UserRole.ToString()))
            .ForMember(dest => dest.SpecializationName, opt
                => opt.MapFrom(src => src.Specialization!.Name))
            .ForMember(dest => dest.Branch, opt
                => opt.MapFrom(src => src.Branch))
            .ForMember(dest => dest.Schedules, opt
                => opt.MapFrom(src => src.Schedules));
    }
}