using AutoMapper;
using MedCare.BLL.Models.Users;

namespace MedCare.API.Contracts.Responses.Account;

public class GetCurrentUserResponse
{
    public Guid Id { get; init; }
    public string UserRole { get; init; } = string.Empty;
    
    // public byte[]? Image { get; init; } = [];
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Patronymic { get; init; } = string.Empty;
    // public DateTime BirthDate { get; init; }
    // public string Email { get; init; } = string.Empty;
    // public string PhoneNumber { get; init; } = string.Empty;
}

public class GetUserRoleProfile : Profile
{
    public GetUserRoleProfile()
    {
        CreateMap<UserModel, GetCurrentUserResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserRole, opt
                => opt.MapFrom(src => src.UserRole))
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.UserProfile.LastName))
            .ForMember(dest => dest.Patronymic, opt
                => opt.MapFrom(src => src.UserProfile.Patronymic));
    }
}