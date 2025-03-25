using Application.Models;
using MediatR;

namespace Application.Features.Visits.CreateVisit;

public record CreateVisitCommand(DateTime VisitStartDate, DateTime VisitEndDate, DateTime CompletionDate,
    string Status, decimal TotalPrice, int CustomerId, int CarId): IRequest<int>;