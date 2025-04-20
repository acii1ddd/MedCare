using AutoMapper;
using MedCare.API.Contracts.Responses.Branches;
using MedCare.API.Contracts.Responses.Schedules;
using MedCare.BLL.Models.Users;

namespace MedCare.API.Contracts.Responses.Workers;

public class GetDoctorResponse
{
    public Guid Id { get; init; }
    
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string Patronymic { get; init; } = string.Empty;
    
    public string PhoneNumber { get; init; } = string.Empty;
    
    public string Email { get; init; } = string.Empty;
    
    public string SpecializationName { get; init; } = string.Empty;
    
    public byte[] Image { get; init; } = [];

    public List<GetScheduleResponse> Schedules { get; init; } = [];

    public GetBranchResponse Branch { get; init; } = null!;
}

public class GetDoctorResponseProfile : Profile
{
    public GetDoctorResponseProfile()
    {
        CreateMap<UserModel, GetDoctorResponse>()
            .BeforeMap((src, dest) =>
            {
                if (src.Specialization == null)
                    throw new InvalidOperationException($"Worker {src.UserProfile.Email} не является врачом");
            })
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.UserProfile.LastName))
            .ForMember(dest => dest.Patronymic, opt
                => opt.MapFrom(src => src.UserProfile.Patronymic))
            .ForMember(dest => dest.PhoneNumber, opt
                => opt.MapFrom(src => src.UserProfile.PhoneNumber))
            .ForMember(dest => dest.Email, opt
                => opt.MapFrom(src => src.UserProfile.Email))
            .ForMember(dest => dest.SpecializationName, opt
                => opt.MapFrom(src => src.Specialization!.Name))
            .ForMember(dest => dest.Image, opt
                => opt.MapFrom(src => src.UserProfile.Image))
            .ForMember(dest => dest.Schedules, opt
                => opt.MapFrom(src => src.Schedules))
            .ForMember(dest => dest.Branch, opt
                => opt.MapFrom(src => src.Branch));
    }
}