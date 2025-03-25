using Application.Interfaces;
using MediatR;

namespace Application.Features.Customers.SoftDeleteCustomer;

public class SoftDeleteCustomerCommandHandler : IRequestHandler<SoftDeleteCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository;

    public SoftDeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        
        await _customerRepository.SoftDeleteAsync(customer.Id);
    }
}