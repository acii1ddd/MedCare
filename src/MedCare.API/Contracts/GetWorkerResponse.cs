using AutoMapper;
using MedCare.BLL.Models.Users;

namespace MedCare.API.Contracts;

public class GetWorkerResponse
{
    public string FirstName { get; init; } = string.Empty;
    
    public string LastName { get; init; } = string.Empty;
    
    public string Patronymic { get; init; } = string.Empty;
    
    public string PhoneNumber { get; init; } = string.Empty;
    
    public string SpecializationName { get; init; } = string.Empty;
    
    public byte[] Image { get; init; } = [];
}

public class GetWorkerResponseProfile : Profile
{
    public GetWorkerResponseProfile()
    {
        CreateMap<UserModel, GetWorkerResponse>()
            .BeforeMap((src, dest) =>
            {
                if (src.Specialization == null)
                    throw new InvalidOperationException($"Worker {src.UserProfile.Email} не является врачом");
            })
            .ForMember(dest => dest.FirstName, opt
                => opt.MapFrom(src => src.UserProfile.FirstName))
            .ForMember(dest => dest.LastName, opt
                => opt.MapFrom(src => src.UserProfile.LastName))
            .ForMember(dest => dest.Patronymic, opt
                => opt.MapFrom(src => src.UserProfile.Patronymic))
            .ForMember(dest => dest.PhoneNumber, opt
                => opt.MapFrom(src => src.UserProfile.PhoneNumber))
            .ForMember(dest => dest.SpecializationName, opt
                => opt.MapFrom(src => src.Specialization!.Name))
            .ForMember(dest => dest.Image, opt
            => opt.MapFrom(src => src.UserProfile.Image));
    }
}