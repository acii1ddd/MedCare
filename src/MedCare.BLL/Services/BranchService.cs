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
}