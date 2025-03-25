using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitsByCustomerId;

public class GetVisitsByCustomerIdQueryHandler : IRequestHandler<GetVisitsByCustomerIdQuery, IEnumerable<Visit>>
{
    private readonly IVisitRepository _repository;

    public GetVisitsByCustomerIdQueryHandler(IVisitRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Visit>> Handle(GetVisitsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var visits = await _repository.GetVisitsByCustomerIdAsync(request.Id);
        return visits.Where(v => v.DeletedAt == null);
    }
}