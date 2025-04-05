using AutoMapper;
using MedCare.API.Contracts.Responses;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly IWorkerService _workerService;
    private readonly IMapper _mapper;
    
    public DoctorController(IWorkerService workerService, IMapper mapper)
    {
        _workerService = workerService;
        _mapper = mapper;
    }
    
    // api/doctors/branchName?specialization=spec
    [HttpGet("{branchName}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetWorkerResponse))]
    public async Task<IActionResult> GetAllByBranchNameWithFilterAsync(
        [FromRoute] string branchName, [FromQuery] Guid? specializationId)
    {
        var doctors = await _workerService.GetByBranchNameWithFilterAsync(branchName, specializationId);
        return Ok(_mapper.Map<List<GetWorkerResponse>>(doctors));
    }
    
    [HttpGet("{doctorId:guid}/available-days")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAvailableDaysResponse))]
    public async Task<IActionResult> GetAvailableDaysForDoctorAsync(
        [FromRoute] Guid doctorId, 
        [FromQuery] DateTime? startDate, 
        [FromQuery] DateTime? endDate)
    {
        var days = await _workerService.GetAvailableDaysForDoctorAsync(doctorId, startDate, endDate);
        return Ok(_mapper.Map<GetAvailableDaysResponse>(days));
    }
}