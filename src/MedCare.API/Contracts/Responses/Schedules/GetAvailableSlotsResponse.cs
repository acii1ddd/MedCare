using AutoMapper;

namespace MedCare.API.Contracts.Responses.Schedules;

public class GetAvailableSlotsResponse
{
    public required List<DateTime> Slots { get; init; }
}

public class GetAvailableSlotsResponseProfile : Profile
{
    public GetAvailableSlotsResponseProfile()
    {
        CreateMap<List<DateTime>, GetAvailableSlotsResponse>()
            .ForMember(dest => dest.Slots, opt 
                => opt.MapFrom(src => src ?? new List<DateTime>()));
    }
}