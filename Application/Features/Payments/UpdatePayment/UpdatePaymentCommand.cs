using MediatR;

namespace Application.Features.Payments.UpdatePayment;

public record UpdatePaymentCommand(int Id, decimal? Amount,
    string? PaymentMethod, string? Status, string? Currency) : IRequest;