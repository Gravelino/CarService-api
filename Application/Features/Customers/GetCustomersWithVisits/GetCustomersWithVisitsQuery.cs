using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetCustomersWithVisits;

public class GetCustomersWithVisitsQuery : IRequest<IEnumerable<Customer>>
{
    
}