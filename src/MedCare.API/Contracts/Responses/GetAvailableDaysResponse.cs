using AutoMapper;

namespace MedCare.API.Contracts.Responses;

public class GetAvailableDaysResponse
{
    public required List<DateTime> AvailableDays { get; init; }
}

public class GetAvailableDaysResponseProfile : Profile
{
    public GetAvailableDaysResponseProfile()
    {
        CreateMap<List<DateTime>, GetAvailableDaysResponse>()
            .ForMember(dest => dest.AvailableDays, opt 
                => opt.MapFrom(src => src ?? new List<DateTime>()));
    }
}