using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetWorkerWithScheduledVisitsById;

public class GetWorkerWithScheduledVisitsByIdQueryHandler : IRequestHandler<GetWorkerWithScheduledVisitsByIdQuery, Worker?>
{
    private readonly IWorkerRepository _repository;

    public GetWorkerWithScheduledVisitsByIdQueryHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Worker?> Handle(GetWorkerWithScheduledVisitsByIdQuery request, CancellationToken cancellationToken)
    {
        var worker = await _repository.GetWorkerWithScheduledVisitsByIdAsync(request.WorkerId);
        return worker;
    }
}