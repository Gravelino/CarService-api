using Application.Interfaces;
using MediatR;

namespace Application.Features.Customers.RestoreCustomer;

public class RestoreCustomerCommandHandler : IRequestHandler<RestoreCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public RestoreCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        
        await _customerRepository.RestoreAsync(customer.Id);
    }
}