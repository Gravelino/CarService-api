using MediatR;

namespace Application.Features.Payments.CreatePayment;

public record CreatePaymentCommand(decimal Amount, string PaymentMethod, string Status, string Currency, int VisitId) : IRequest<int>;