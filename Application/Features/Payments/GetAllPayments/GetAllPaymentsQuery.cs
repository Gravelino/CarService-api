using Application.Models;
using MediatR;

namespace Application.Features.Payments.GetAllPayments;

public class GetAllPaymentsQuery : IRequest<IEnumerable<Payment>>
{
    
}