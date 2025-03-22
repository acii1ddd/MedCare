using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts;

public class GetSpecializationResponse
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
}

public class GetSpecializationResponseProfile : Profile
{
    public GetSpecializationResponseProfile()
    {
        CreateMap<SpecializationModel, GetSpecializationResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt
                => opt.MapFrom(src => src.Description));
    }
}