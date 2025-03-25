using MediatR;

namespace Application.Features.Workers.UpdateWorker;

public record UpdateWorkerCommand(int Id,string? FirstName, string? LastName,string? Specialization,
    DateTime? HireDate, string? Phone, string? Email, decimal? Salary, bool? IsActive): IRequest;