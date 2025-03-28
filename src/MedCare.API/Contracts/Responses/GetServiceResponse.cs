using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses;

public class GetServiceResponse
{
    public Guid Id { get; init; }
    
    public string Name { get; init; } = string.Empty;
    
    public decimal Price { get; init; }
}

public class GetServiceResponseProfile : Profile
{
    public GetServiceResponseProfile()
    {
        CreateMap<ServiceModel, GetServiceResponse>()
            .ForMember(dest => dest.Id, opt
                => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt
                => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Price, opt
                => opt.MapFrom(src => src.Price));
    }
}