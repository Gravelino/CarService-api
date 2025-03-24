using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitsByCustomerId;

public class GetVisitsByCustomerIdQuery : IRequest<IEnumerable<Visit>>
{
    public int Id { get; set; }
}