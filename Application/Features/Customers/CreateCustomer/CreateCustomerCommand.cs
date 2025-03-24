using MediatR;

namespace Application.Features.Customers.CreateCustomer;

public record CreateCustomerCommand(string FirstName, string LastName, string Phone, string Email, string Address) : IRequest<int>;