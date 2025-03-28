using AutoMapper;
using MedCare.BLL.Models.Auth;
using MedCare.DAL.Entities.Users;

namespace MedCare.API.Contracts.Responses.Account;

public class SignInResponse
{
    public Guid UserId { get; init; }
    
    public UserRole UserRole { get; init; }
    
    public string AccessToken { get; init; } = string.Empty;
    
    public DateTime Expires { get; init; }
}

public class SignInRequestProfile : Profile
{
    public SignInRequestProfile()
    {
        CreateMap<AuthAccessTokenModel, SignInResponse>();
    }
}
