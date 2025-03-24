using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Visits.GetAllVisits;

public class GetAllVisitsQueryHandler : IRequestHandler<GetAllVisitsQuery, IEnumerable<Visit>>
{
    private readonly IVisitRepository _repository;

    public GetAllVisitsQueryHandler(IVisitRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Visit>> Handle(GetAllVisitsQuery request, CancellationToken cancellationToken)
    {
        var visits = await _repository.GetAllAsync();
        return visits.Where(v => v.DeletedAt == null);
    }
}