using MediatR;

namespace Application.Features.Customers.RestoreCustomer;

public record RestoreCustomerCommand(int Id) : IRequest;