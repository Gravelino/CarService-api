using Application.Interfaces;
using MediatR;

namespace Application.Features.Workers.RestoreWorker;

public class RestoreWorkerCommandHandler : IRequestHandler<RestoreWorkerCommand>
{
    private readonly IWorkerRepository _workerRepository;

    public RestoreWorkerCommandHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }
    
    public async Task Handle(RestoreWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.GetByIdAsync(request.Id);
        if (worker == null)
        {
            throw new Exception("Worker not found");
        }
        
        await _workerRepository.RestoreAsync(worker.Id);
    }
}