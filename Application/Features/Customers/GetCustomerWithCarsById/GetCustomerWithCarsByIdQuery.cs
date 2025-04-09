using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetCustomerWithCarsById;

public class GetCustomerWithCarsByIdQuery : IRequest<Customer?>
{
    public int CustomerId { get; set; }
}