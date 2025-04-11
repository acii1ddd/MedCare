using AutoMapper;
using MedCare.API.Contracts;
using MedCare.API.Contracts.Responses;
using MedCare.API.Contracts.Responses.Branches;
using MedCare.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync()
    {
        var branches = await _branchService.GetAllAsync();
        var result = _mapper.Map<List<GetBranchNameResponse>>(branches);
        return Ok(result);
    }
}