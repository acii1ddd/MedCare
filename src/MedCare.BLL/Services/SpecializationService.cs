using AutoMapper;
using MedCare.BLL.Interfaces;
using MedCare.BLL.Models;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

public class SpecializationService : ISpecializationService
{
    private readonly IMapper _mapper;
    private readonly ISpecializationRepository _specializationRepository;
    
    public SpecializationService(IMapper mapper, ISpecializationRepository specializationRepository)
    {
        _mapper = mapper;
        _specializationRepository = specializationRepository;
    }
    
    public async Task<List<SpecializationModel>> GetByBranchAsync(Guid branchId)
    {
        return _mapper.Map<List<SpecializationModel>>(
            await _specializationRepository.GetByBranchAsync(branchId)
        );
    }
}
