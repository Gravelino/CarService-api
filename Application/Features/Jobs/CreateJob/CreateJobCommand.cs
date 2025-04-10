using MediatR;

namespace Application.Features.Jobs.CreateJob;

public record CreateJobCommand(decimal Price, int VisitId, int ServiceId, int WorkerId) : IRequest<int>;