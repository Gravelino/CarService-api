using Application.Models;
using MediatR;

namespace Application.Features.Cars.GetCarsByCustomerId;

public class GetCarsByCustomerIdQuery : IRequest<IEnumerable<Car>>
{
    public int CustomerId { get; set; }
}