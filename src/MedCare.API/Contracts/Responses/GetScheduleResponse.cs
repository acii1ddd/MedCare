using AutoMapper;
using MedCare.BLL.Models;

namespace MedCare.API.Contracts.Responses;

public class GetScheduleResponse
{
    public DayOfWeek DayOfWeek { get; init; }
    
    public TimeSpan StartTime { get; init; }
    
    public TimeSpan EndTime { get; init; }
}

public class GetScheduleResponseProfile : Profile
{
    public GetScheduleResponseProfile()
    {
        CreateMap<ScheduleModel, GetScheduleResponse>();
    }
}
