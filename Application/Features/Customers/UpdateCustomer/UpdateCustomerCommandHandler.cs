using Application.DTOs;
using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Customers.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }
        
        if(request.FirstName is not null) customer.FirstName = request.FirstName;
        if(request.LastName is not null) customer.LastName = request.LastName;
        if(request.Phone is not null) customer.Phone = request.Phone;
        if(request.Email is not null) customer.Email = request.Email;

        await _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
        
        return new CustomerDto
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Phone = customer.Phone,
            Email = customer.Email
        };
    }
}