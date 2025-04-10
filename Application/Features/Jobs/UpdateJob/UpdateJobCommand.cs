using MediatR;

namespace Application.Features.Jobs.UpdateJob;

public record UpdateJobCommand(int JobId, decimal? Price, int? ServiceId, int? WorkerId) : IRequest;