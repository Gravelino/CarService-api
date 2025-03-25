using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Payments.CreatePayment;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IPaymentRepository _paymentRepository;

    public CreatePaymentCommandHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    
    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Amount = request.Amount,
            Currency = request.Currency,
            PaymentMethod = request.PaymentMethod,
            PaymentDate = DateTime.UtcNow,
            Status = request.Status,
            VisitId = request.VisitId
        };
        
        await _paymentRepository.AddAsync(payment);
        await _paymentRepository.SaveChangesAsync();
        
        return payment.Id;
    }
}