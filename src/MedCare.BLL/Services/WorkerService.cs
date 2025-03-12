using AutoMapper;
using MedCare.BLL.Interfaces;
using MedCare.Common.Models.Users;
using MedCare.DAL.Interfaces;

namespace MedCare.BLL.Services;

internal class WorkerService : IWorkerService
{
    private readonly IWorkerRepository _workerRepository;
    private readonly IMapper _mapper;

    public WorkerService(IWorkerRepository workerRepository, IMapper mapper)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
    }

    public async Task<List<WorkerModel>> GetAllByBranchNameAsync(string branchName)
    {
        var workers = _mapper.Map<List<WorkerModel>>(await _workerRepository.GetAllByBranchNameAsync(branchName));
        return workers;
    }
}