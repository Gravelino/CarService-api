using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Customers.SoftDeleteCustomer;

public class SoftDeleteCustomerCommandHandler : IRequestHandler<SoftDeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public SoftDeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            return false;
        }
        
        await _customerRepository.SoftDeleteAsync(customer.Id);
        
        return true;
    }
}