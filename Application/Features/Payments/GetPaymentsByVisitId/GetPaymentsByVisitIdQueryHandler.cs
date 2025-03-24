using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Payments.GetPaymentsByVisitId;

public class GetPaymentsByVisitIdQueryHandler : IRequestHandler<GetPaymentsByVisitIdQuery, IEnumerable<Payment>>
{
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentsByVisitIdQueryHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<Payment>> Handle(GetPaymentsByVisitIdQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetPaymentsByVisitIdAsync(request.VisitId);
        return payments;
    }
}