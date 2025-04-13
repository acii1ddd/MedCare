using AutoMapper;
using MedCare.API.Contracts.Requests;
using MedCare.API.Contracts.Responses;
using MedCare.BLL.Models;
using MedCare.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : BaseController
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;
    
    public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddAppointmentResponse))]
    public async Task<IActionResult> AddAsync([FromBody] AddAppointmentRequest request)
    {
        var appointment = await _appointmentService.AddAsync(
            _mapper.Map<AppointmentModel>(request), AuthorizedUserId
        );
        
        return Ok(_mapper.Map<AddAppointmentResponse>(appointment));
    }
    
    // [HttpGet]
    // [Authorize]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAppointmentResponse>))]
    // public async Task<IActionResult> GetAllWithFilter([FromBody] AddAppointmentRequest request)
    // {
    //     var appointment = await _appointmentService.AddAsync(
    //         _mapper.Map<AppointmentModel>(request), AuthorizedUserId
    //     );
    //     
    //     return Ok(_mapper.Map<List<GetAppointmentResponse>>(appointment));
    // }
}
