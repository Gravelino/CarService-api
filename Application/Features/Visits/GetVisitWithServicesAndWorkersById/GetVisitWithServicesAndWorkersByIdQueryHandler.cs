using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitWithServicesAndWorkersById;

public class GetVisitWithServicesAndWorkersByIdQueryHandler : IRequestHandler<GetVisitWithServicesAndWorkersByIdQuery, Visit?>
{
    private readonly IVisitRepository _repository;

    public GetVisitWithServicesAndWorkersByIdQueryHandler(IVisitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Visit?> Handle(GetVisitWithServicesAndWorkersByIdQuery request, CancellationToken cancellationToken)
    {
        var visit = await _repository.GetVisitWithServicesAndWorkersByIdAsync(request.VisitId);
        return visit;
    }
}