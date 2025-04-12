using AutoMapper;

namespace MedCare.API.Contracts.Responses.Schedules;

public class GetAvailableDaysResponse
{
    public required List<DateTime> Days { get; init; }
}

public class GetAvailableDaysResponseProfile : Profile
{
    public GetAvailableDaysResponseProfile()
    {
        CreateMap<List<DateTime>, GetAvailableDaysResponse>()
            .ForMember(dest => dest.Days, opt 
                => opt.MapFrom(src => src ?? new List<DateTime>()));
    }
}