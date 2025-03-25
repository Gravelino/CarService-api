using MediatR;

namespace Application.Features.Visits.SoftDeleteVisit;

public record SoftDeleteVisitCommand(int Id) : IRequest;