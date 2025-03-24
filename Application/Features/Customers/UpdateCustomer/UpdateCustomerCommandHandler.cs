using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Customers.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            return false;
        }
        
        if(request.FirstName is not null) customer.FirstName = request.FirstName;
        if(request.LastName is not null) customer.LastName = request.LastName;
        if(request.Phone is not null) customer.Phone = request.Phone;
        if(request.Email is not null) customer.Email = request.Email;
        if(request.Address is not null) customer.Address = request.Address;

        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
        
        return true;
    }
}