using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetAllWorkers;

public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery, IEnumerable<Worker>>
{
    private readonly IWorkerRepository _repository;

    public GetAllWorkersQueryHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Worker>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
    {
        var workers =  await _repository.GetAllAsync();
        return workers.Where(w => w.DeletedAt == null);
    }
}