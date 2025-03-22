using AutoMapper;
using MedCare.API.Contracts;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/branches")]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;
    private readonly IMapper _mapper;
    
    public BranchController(
        IBranchService branchService, 
        IMapper mapper)
    {
        _branchService = branchService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var branches = await _branchService.GetAllAsync();
        var result = _mapper.Map<List<GetBranchNameResponse>>(branches);
        return Ok(result);
    }
    
    [HttpGet("{branchId:guid}/specializations")]
    public async Task<IActionResult> GetSpecializationsForBranchAsync(Guid branchId)
    {
        var specializations = await _branchService.GetByBranchAsync(branchId);
        var result = _mapper.Map<List<GetSpecializationResponse>>(specializations);
        return Ok(result);
    }
    
    [HttpGet("{branchId:guid}/specializations/{specializationId:guid}/services")]
    public async Task<IActionResult> GetServicesBySpecializationForBranchAsync(Guid branchId, Guid specializationId)
    {
        var services = await _branchService.GetServicesBySpecializationForBranch(specializationId, branchId);
        var result = _mapper.Map<List<GetServiceResponse>>(services);
        return Ok(result);
    }
}