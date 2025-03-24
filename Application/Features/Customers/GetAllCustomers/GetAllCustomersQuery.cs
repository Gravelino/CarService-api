using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
{
    
}