using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<Customer?>
{
    public int Id { get; set; }
}