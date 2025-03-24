using MediatR;

namespace Application.Features.Payments.RestorePayment;

public record RestorePaymentCommand(int Id) : IRequest<bool>;