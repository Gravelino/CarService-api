using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Payments.GetTotalPaymentsForVisit;

public class GetTotalPaymentsForVisitQueryHandler : IRequestHandler<GetTotalPaymentsForVisitQuery, decimal>
{
    private readonly IPaymentRepository _repository;

    public GetTotalPaymentsForVisitQueryHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<decimal> Handle(GetTotalPaymentsForVisitQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetTotalPaymentsForVisitAsync(request.VisitId);
        return result;
    }
}