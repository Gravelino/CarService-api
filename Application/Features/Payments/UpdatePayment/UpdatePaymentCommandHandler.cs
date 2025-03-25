using Application.Interfaces;
using MediatR;

namespace Application.Features.Payments.UpdatePayment;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;

    public UpdatePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    
    public async Task Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);
        if (payment == null)
        {
            throw new Exception("Payment not found");
        }
        
        if(request.PaymentMethod is not null) payment.PaymentMethod = request.PaymentMethod;
        if(request.Status is not null) payment.Status = request.Status;
        if(request.Amount is not null) payment.Amount = (decimal)request.Amount;
        if(request.Currency is not null) payment.Currency = request.Currency;

        _paymentRepository.Update(payment);
        await _paymentRepository.SaveChangesAsync();
    }
}