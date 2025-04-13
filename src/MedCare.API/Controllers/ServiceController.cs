using AutoMapper;
using MedCare.API.Contracts.Responses;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/services")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public ServiceController(IMapper mapper, IServiceService serviceService)
    {
        _mapper = mapper;
        _serviceService = serviceService;
    }

    [HttpGet("{branchId:guid}/services")]
    public async Task<IActionResult> GetByBranchWithFilterAsync([FromRoute] Guid branchId, [FromQuery] Guid specializationId)
    {
        var services = await _serviceService.GetByBranchWithFilterAsync(branchId, specializationId);
        var result = _mapper.Map<List<GetServiceResponse>>(services);
        return Ok(result);
    }
}