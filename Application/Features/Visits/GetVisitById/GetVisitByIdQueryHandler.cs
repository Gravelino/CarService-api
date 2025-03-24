using Application.Features.Visits.GetAllVisits;
using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Visits.GetVisitById;

public class GetVisitByIdQueryHandler : IRequestHandler<GetVisitByIdQuery, Visit?>
{
    private readonly IVisitRepository _repository;

    public GetVisitByIdQueryHandler(IVisitRepository repository)
    {
        _repository = repository;
    }

    public async Task<Visit?> Handle(GetVisitByIdQuery request, CancellationToken cancellationToken)
    {
        var visit = await _repository.GetByIdAsync(request.Id);
        return visit;
    }
}