using AutoMapper;
using MedCare.API.Contracts.Requests;
using MedCare.API.Contracts.Responses;
using MedCare.API.Contracts.Responses.Appointments;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.BLL.Services;
using MedCare.DAL.Entities.Appointments;
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

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetAppointmentResponseWithCards>))]
    public async Task<IActionResult> GetAllWithFilter(
        [FromQuery] DateTime? visitDate,
        [FromQuery] AppointmentStatus? appointmentStatus,
        [FromQuery] PaymentStatus? paymentStatus,
        [FromQuery] Guid? patientId,
        [FromQuery] Guid? doctorId)
    {
        var appointments = await _appointmentService.GetAllWithFilterAsync(
            visitDate, appointmentStatus, paymentStatus, patientId, doctorId
        );

        var mapped = _mapper.Map<List<GetAppointmentResponseWithCards>>(appointments); 
        return Ok(mapped);
    }
    
    [HttpPost("{appointmentId:guid}/complete")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SetToCompletedAsync([FromRoute] Guid appointmentId)
    {
        await _appointmentService.SetToCompletedAsync(appointmentId);
        return Ok();
    }
}