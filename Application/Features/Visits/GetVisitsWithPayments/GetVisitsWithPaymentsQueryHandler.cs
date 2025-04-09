using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitsWithPayments;

public class GetVisitsWithPaymentsQueryHandler : IRequestHandler<GetVisitsWithPaymentsQuery, IEnumerable<Visit>>
{
    private readonly IVisitRepository _repository;

    public GetVisitsWithPaymentsQueryHandler(IVisitRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Visit>> Handle(GetVisitsWithPaymentsQuery request, CancellationToken cancellationToken)
    {
        var visits = await _repository.GetVisitsWithPaymentsAsync();
        return visits.Where(v => v.DeletedAt == null);
    }
}