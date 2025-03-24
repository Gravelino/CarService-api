using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Payments.SoftDeletePayment;

public class SoftDeletePaymentCommandHandler : IRequestHandler<SoftDeletePaymentCommand, bool>
{
    private readonly IPaymentRepository _paymentRepository;

    public SoftDeletePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    
    public async Task<bool> Handle(SoftDeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);
        if (payment == null)
        {
            return false;
        }
        
        await _paymentRepository.SoftDeleteAsync(payment.Id);
        
        return true;
    }
}