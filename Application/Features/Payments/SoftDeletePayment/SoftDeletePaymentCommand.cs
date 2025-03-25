using MediatR;

namespace Application.Features.Payments.SoftDeletePayment;

public record SoftDeletePaymentCommand(int Id) : IRequest;