using Application.Models;
using MediatR;

namespace Application.Features.Payments.GetPaymentById;

public class GetPaymentByIdQuery : IRequest<Payment?>
{
    public int Id { get; set; }
}