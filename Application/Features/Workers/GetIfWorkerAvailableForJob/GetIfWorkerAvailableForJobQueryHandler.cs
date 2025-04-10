using Application.Interfaces;
using MediatR;

namespace Application.Features.Workers.GetIfWorkerAvailableForJob;

public class GetIfWorkerAvailableForJobQueryHandler : IRequestHandler<GetIfWorkerAvailableForJobQuery, bool>
{
    private readonly IWorkerRepository _workerRepository;

    public GetIfWorkerAvailableForJobQueryHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }

    public async Task<bool> Handle(GetIfWorkerAvailableForJobQuery request, CancellationToken cancellationToken)
    {
        var isAvailable = await _workerRepository.IsWorkerAvailableByIdAsync(request.WorkerId, request.Start, request.End);
        return isAvailable;
    }
}