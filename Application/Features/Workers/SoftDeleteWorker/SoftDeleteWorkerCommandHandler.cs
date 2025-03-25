using Application.Features.Workers.SoftDeleteWorker;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Workers.SoftDeleteWorker;

public class SoftDeleteWorkerCommandHandler : IRequestHandler<SoftDeleteWorkerCommand>
{
    private readonly IWorkerRepository _workerRepository;

    public SoftDeleteWorkerCommandHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }
    
    public async Task Handle(SoftDeleteWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.GetByIdAsync(request.Id);
        if (worker == null)
        {
            throw new Exception("Worker not found");
        }
        
        await _workerRepository.SoftDeleteAsync(worker.Id);
    }
}