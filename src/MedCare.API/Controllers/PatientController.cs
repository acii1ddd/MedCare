using AutoMapper;
using MedCare.API.Contracts.Responses;
using MedCare.API.Contracts.Responses.Workers;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;

    public PatientController(IPatientService patientService, IMapper mapper)
    {
        _patientService = patientService;
        _mapper = mapper;
    }
    
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPatientResponse))]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var patient = await _patientService.GetByIdAsync(id);
        return Ok(_mapper.Map<GetPatientResponse>(patient));
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetPatientResponse>))]
    public async Task<IActionResult> GetAllAsync()
    {
        var patients = await _patientService.GetAllAsync();
        return Ok(_mapper.Map<List<GetPatientResponse>>(patients));
    }
}