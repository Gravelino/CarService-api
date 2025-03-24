using Application.Features.Customers.GetAllCustomers;
using Application.Models;
using Persistence.Repositories.Interfaces;
using MediatR;

namespace Application.Features.Customers.GetTopSpendingCustomers;

public class GetTopSpendingCustomersQueryHandler : IRequestHandler<GetTopSpendingCustomersQuery, IEnumerable<Customer>>
{
    private readonly ICustomerRepository _repository;

    public GetTopSpendingCustomersQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Customer>> Handle(GetTopSpendingCustomersQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetTopSpendingCustomersAsync(request.Limit);
        return customer.Where(c => c.DeletedAt == null).ToList();
    }
}