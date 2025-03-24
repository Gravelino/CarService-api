using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Customers.RestoreCustomer;

public class RestoreCustomerCommandHandler : IRequestHandler<RestoreCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public RestoreCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            return false;
        }
        
        await _customerRepository.RestoreAsync(customer.Id);
        
        return true;
    }
}