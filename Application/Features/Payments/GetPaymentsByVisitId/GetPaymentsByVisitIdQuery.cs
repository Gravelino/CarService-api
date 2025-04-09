using Application.Models;
using MediatR;

namespace Application.Features.Payments.GetPaymentsByVisitId;

public class GetPaymentsByVisitIdQuery : IRequest<IEnumerable<Payment>>
{
    public int VisitId { get; set; }
}