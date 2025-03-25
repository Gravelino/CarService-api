using MediatR;

namespace Application.Features.Customers.SoftDeleteCustomer;

public record SoftDeleteCustomerCommand(int Id) : IRequest;