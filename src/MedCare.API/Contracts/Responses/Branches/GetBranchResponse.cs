using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses.Branches;

public class GetBranchResponse
{
    public string Name { get; set; } = string.Empty;
    
    public string FullAddress { get; set; } = string.Empty;
}

public class GetBranchResponseProfile : Profile
{
    public GetBranchResponseProfile()
    {
        CreateMap<BranchModel, GetBranchResponse>()
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.FullAddress, opt
                => opt.MapFrom(src => $"{src.Address.City.Name}, {src.Address.Street} {src.Address.BuildingNumber.ToString()}"));
    }
}