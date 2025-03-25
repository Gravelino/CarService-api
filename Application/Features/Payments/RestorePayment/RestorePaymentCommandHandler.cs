using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Payments.RestorePayment;

public class RestorePaymentCommandHandler : IRequestHandler<RestorePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;

    public RestorePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task Handle(RestorePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);
        if (payment == null)
        {
            throw new Exception("Payment not found");
        }
        
        await _paymentRepository.RestoreAsync(payment.Id);
    }
}