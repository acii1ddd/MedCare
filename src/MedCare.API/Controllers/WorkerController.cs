using AutoMapper;
using MedCare.API.Contracts.Requests.User;
using MedCare.API.Contracts.Responses.Workers;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models.Users;
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
    
    [HttpDelete("{workerId:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(Guid workerId)
    {
        await _workerService.DeleteAsync(workerId);
        return Ok();
    }
    
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAsync([FromForm] AddWorkerRequest request)
    {
        await _workerService.AddAsync(_mapper.Map<UserModel>(request), request.Image);
        return Ok();
    }
}