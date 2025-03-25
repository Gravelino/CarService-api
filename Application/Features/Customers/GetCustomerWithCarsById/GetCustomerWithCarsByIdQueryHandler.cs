using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetCustomerWithCarsById;

public class GetCustomerWithCarsByIdQueryHandler : IRequestHandler<GetCustomerWithCarsByIdQuery, Customer?>
{
    private readonly ICustomerRepository _repository;

    public GetCustomerWithCarsByIdQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer?> Handle(GetCustomerWithCarsByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetCustomerWithCarsByIdAsync(request.CustomerId);
        return customer;
    }
}