using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetTopSpendingCustomers;

public record GetTopSpendingCustomersQuery : IRequest<IEnumerable<Customer>>
{
    public int Limit { get; set; }
}