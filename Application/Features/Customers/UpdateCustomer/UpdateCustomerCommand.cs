using MediatR;

namespace Application.Features.Customers.UpdateCustomer;

public record UpdateCustomerCommand(int Id, string? FirstName,
    string? LastName, string? Phone, string? Email, string? Address) : IRequest;