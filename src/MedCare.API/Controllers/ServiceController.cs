// using AutoMapper;
// using MedCare.API.Contracts;
// using MedCare.BLL.Interfaces;
// using Microsoft.AspNetCore.Mvc;
//
// namespace MedCare.API.Controllers;
//
// [ApiController]
// [Route("api/services")]
// public class ServiceController : ControllerBase
// {
//     private readonly IServiceService _serviceService;
//     private readonly IMapper _mapper;
//
//     public ServiceController(IMapper mapper, IServiceService serviceService)
//     {
//         _mapper = mapper;
//         _serviceService = serviceService;
//     }
//
//     [HttpGet("{branchId:guid}/specializations/{specializationId:guid}/services")]
//     public async Task<IActionResult> GetBySpecializationForBranchAsync(Guid branchId, Guid specializationId)
//     {
//         var services = await _serviceService.GetServicesBySpecializationForBranch(specializationId, branchId);
//         var result = _mapper.Map<List<GetServiceResponse>>(services);
//         return Ok(result);
//     }
// }