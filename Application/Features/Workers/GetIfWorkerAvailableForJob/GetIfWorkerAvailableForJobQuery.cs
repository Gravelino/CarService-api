using MediatR;

namespace Application.Features.Workers.GetIfWorkerAvailableForJob;

public record GetIfWorkerAvailableForJobQuery(int WorkerId, DateTime Start, DateTime End) : IRequest<bool>;