using AutoMapper;
using MedCare.API.Contracts;
using MedCare.API.Contracts.Responses;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/specializations")]
public class SpecializationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISpecializationService _specializationService;
    
    public SpecializationController(IMapper mapper, ISpecializationService specializationService)
    {
        _mapper = mapper;
        _specializationService = specializationService;
    }

    [HttpGet("{branchId:guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetForBranchAsync(Guid branchId)
    {
        var specializations = await _specializationService.GetByBranchAsync(branchId);
        var result = _mapper.Map<List<GetSpecializationResponse>>(specializations);
        return Ok(result);
    }
}