using MediatR;

namespace Application.Features.Visits.RestoreVisit;

public record RestoreVisitCommand(int Id): IRequest;