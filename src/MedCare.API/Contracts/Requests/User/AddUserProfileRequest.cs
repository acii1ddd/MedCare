using AutoMapper;
using MedCare.BLL.Models.Users;
using MedCare.DAL.Entities.Users;

namespace MedCare.API.Contracts.Requests.User;

public class AddUserProfileRequest
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Patronymic { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public Gender Gender { get; init; }
    public string Email { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public byte[]? Image { get; init; } = [];
    public string PassportSeries { get; init; } = string.Empty;
    public string PassportNumber { get; init; } = string.Empty;
}

public class AddUserProfileProfile : Profile
{
    public AddUserProfileProfile()
    {
        CreateMap<AddUserProfileRequest, UserProfileModel>();
    }
}