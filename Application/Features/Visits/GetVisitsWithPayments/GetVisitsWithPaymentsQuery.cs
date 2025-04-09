using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitsWithPayments;

public class GetVisitsWithPaymentsQuery : IRequest<IEnumerable<Visit>>
{
    
}