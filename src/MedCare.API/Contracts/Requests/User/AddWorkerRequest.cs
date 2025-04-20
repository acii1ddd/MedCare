using AutoMapper;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.API.Contracts.Requests.User;

public class AddWorkerRequest
{
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    
    public UserRole UserRole { get; init; }

    public AddUserProfileRequest UserProfile { get; init; } = null!;
    
    public IFormFile? Image;
    
    /// <summary>
    /// Специализация доктора
    /// </summary>
    public Guid SpecializationId { get; init; }
    
    /// <summary>
    /// Филиал, в котором работает работник
    /// </summary>
    public Guid BranchId { get; init; }
}

public class AddWorkerRequestProfile : Profile
{
    public AddWorkerRequestProfile()
    {
        CreateMap<AddWorkerRequest, UserModel>()
            .ForMember(dest => dest.UserProfile, opt
                => opt.MapFrom(src => src.UserProfile))
            .ForMember(dest => dest.SpecializationId, opt
                => opt.MapFrom(src => src.SpecializationId))
            .ForMember(dest => dest.BranchId, opt
                => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.PasswordHash, opt
                => opt.MapFrom(src => src.Password));
    }
}