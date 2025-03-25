using MediatR;

namespace Application.Features.Visits.UpdateVisit;

public record UpdateVisitCommand(int Id, DateTime? VisitStartDate, DateTime? VisitEndDate,
    DateTime? CompletionDate, string? Status, decimal? TotalPrice, int? CustomerId, int? CarId): IRequest;