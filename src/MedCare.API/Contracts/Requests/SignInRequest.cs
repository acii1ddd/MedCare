using AutoMapper;
using MedCare.BLL.Models.Auth;

namespace MedCare.API.Contracts.Requests;

public class SignInRequest
{
    public string Login { get; init; } = string.Empty;
    
    public string Password { get; init; } = string.Empty;
}

public class SignInRequestProfile : Profile
{
    public SignInRequestProfile()
    {
        CreateMap<SignInRequest, SignInModel>();
    }
}