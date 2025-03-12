using AutoMapper;
using MedCare.API.Contracts;
using MedCare.BLL.Interfaces;
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
    
    // api/doctors/branchName
    [HttpGet("{branchName}")]
    public async Task<IActionResult> GetAllByBranchNameAsync([FromRoute] string branchName)
    {
        var workers = await _workerService.GetAllByBranchNameAsync(branchName);
        return Ok(_mapper.Map<List<GetWorkerResponse>>(workers));
    }
}

