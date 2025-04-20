using AutoMapper;
using MedCare.API.Contracts.Responses.Workers;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedCare.API.Controllers;

[ApiController]
[Route("api/workers")]
public class WorkerController : ControllerBase
{
    private readonly IWorkerService _workerService;
    private readonly IMapper _mapper;

    public WorkerController(IWorkerService workerService, IMapper mapper)
    {
        _workerService = workerService;
        _mapper = mapper;
    }

    
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetWorkerResponse>))]
    public async Task<IActionResult> GetAllAsync()
    {
        var workers = await _workerService.GetAllAsync();
        return Ok(_mapper.Map<List<GetWorkerResponse>>(workers));
    }
}