using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetAvailableWorkers;

public class GetAvailableWorkersQueryHandler : IRequestHandler<GetAvailableWorkersQuery, IEnumerable<Worker>>
{
    private readonly IWorkerRepository _repository;

    public GetAvailableWorkersQueryHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Worker>> Handle(GetAvailableWorkersQuery request, CancellationToken cancellationToken)
    {
        var workers = await _repository.GetAvailableWorkersAsync();
        return workers.Where(w => w.DeletedAt == null);
    }
}