using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Payments.GetAllPayments;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<Payment>>
{
    private readonly IPaymentRepository _repository;

    public GetAllPaymentsQueryHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _repository.GetAllAsync();
        return payments.Where(f => f.DeletedAt == null);
    }
}