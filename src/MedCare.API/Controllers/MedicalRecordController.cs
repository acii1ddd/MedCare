using AutoMapper;
using MedCare.API.Contracts.Requests;
using MedCare.API.Contracts.Responses;
using MedCare.API.Contracts.Responses.MedicalRecords;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/medical-records")]
public class MedicalRecordController : ControllerBase
{
    private readonly IMedicalRecordService _medicalRecordService;
    private readonly IMapper _mapper;


    public MedicalRecordController(IMedicalRecordService medicalRecordService, IMapper mapper)
    {
        _medicalRecordService = medicalRecordService;
        _mapper = mapper;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddMedicalRecordResponse))]
    public async Task<IActionResult> AddAsync([FromBody] AddMedicalRecordRequest request)
    {
        var medicalRecord = await _medicalRecordService.AddAsync(
            _mapper.Map<MedicalRecordModel>(request)
        );
        
        return Ok(_mapper.Map<AddMedicalRecordResponse>(medicalRecord));
    }
    
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetMedicalRecordResponse>))]
    public async Task<IActionResult> GetAllAsync()
    {
        var medicalRecords = await _medicalRecordService.GetAllAsync();
        return Ok(_mapper.Map<List<AddMedicalRecordResponse>>(medicalRecords));
    }
}