using AutoMapper;
using MedCare.API.Contracts.Requests;
using MedCare.BLL.Models;
using MedCare.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;
    
    public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AppointmentModel))]
    public async Task<IActionResult> AddAsync([FromBody] AddAppointmentRequestContract request)
    {
        var appointment = await _appointmentService.AddAsync(_mapper.Map<AppointmentModel>(request));
        return Ok(appointment);
    }
}