// using AutoMapper;
// using MedCare.BLL.Interfaces;
// using MedCare.BLL.Models;
// using MedCare.DAL.Interfaces;
//
// namespace MedCare.BLL.Services;
//
// public class ServiceService : IServiceService
// {
//     private readonly IServiceRepository _serviceRepository;
//     private readonly IMapper _mapper;
//
//     public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
//     {
//         _serviceRepository = serviceRepository;
//         _mapper = mapper;
//     }
//     
//     public async Task<List<ServiceModel>> GetServicesBySpecializationForBranch(Guid specializationId, Guid branchId)
//     {
//         return _mapper.Map<List<ServiceModel>>(
//             await _serviceRepository.GetBySpecializationForBranchAsync(specializationId, branchId)
//         );
//     }
// }