using AutoMapper;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

public class BranchService : IBranchService
{
    private readonly IBranchRepository _branchRepository;
    private readonly IMapper _mapper;
    
    
    public BranchService(IBranchRepository branchRepository, IMapper mapper)
    {
        _branchRepository = branchRepository;
        _mapper = mapper;
    }

    public async Task<List<BranchModel>> GetAllAsync()
    {
        return _mapper.Map<List<BranchModel>>(await _branchRepository.GetAllAsync());
    }

    public async Task<List<SpecializationModel>> GetByBranchAsync(Guid branchId)
    {
        return _mapper.Map<List<SpecializationModel>>(
            await _branchRepository.GetSpecializationsByBranchAsync(branchId)
        );
    }

    public async Task<List<ServiceModel>> GetServicesBySpecializationForBranch(Guid specializationId, Guid branchId)
    {
        return _mapper.Map<List<ServiceModel>>(
            await _branchRepository.GetServicesBySpecializationForBranchAsync(specializationId, branchId)
        );
    }
}