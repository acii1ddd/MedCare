using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses;

public class GetBranchNameResponse
{
    public Guid Id { get; init; }
    
    public string Name { get; init; } = string.Empty;
}

public class GetBranchNameResponseProfile : Profile
{
    public GetBranchNameResponseProfile()
    {
        CreateMap<BranchModel, GetBranchNameResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name));
    }
}