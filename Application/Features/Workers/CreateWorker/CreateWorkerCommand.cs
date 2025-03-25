using MediatR;

namespace Application.Features.Workers.CreateWorker;

public record CreateWorkerCommand(string FirstName, string LastName,string Specialization,
    DateTime? HireDate, string Phone, string Email, decimal Salary, bool IsActive): IRequest<int>;