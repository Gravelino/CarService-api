using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Customers.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            RegistrationDate = DateTime.UtcNow
        };
        
        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();
        
        return customer.Id;
    }
}