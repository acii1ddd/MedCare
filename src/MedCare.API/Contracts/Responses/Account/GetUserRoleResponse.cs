using AutoMapper;

namespace MedCare.API.Contracts.Responses.Account;

public class GetUserRoleResponse
{
    public string UserRole { get; init; } = string.Empty;
}

public class GetUserRoleProfile : Profile
{
    public GetUserRoleProfile()
    {
        CreateMap<string, GetUserRoleResponse>()
            .ForMember(dest => dest.UserRole, opt 
                => opt.MapFrom(src => src));
    }
}