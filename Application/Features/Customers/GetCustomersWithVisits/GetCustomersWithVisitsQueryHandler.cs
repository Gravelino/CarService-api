using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Customers.GetCustomersWithVisits;

public class GetCustomersWithVisitsQueryHandler : IRequestHandler<GetCustomersWithVisitsQuery, IEnumerable<Customer>>
{
    private readonly ICustomerRepository _repository;

    public GetCustomersWithVisitsQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> Handle(GetCustomersWithVisitsQuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetCustomersWithVisitsAsync();
        return customers.Where(c => c.DeletedAt == null).ToList();
    }
}