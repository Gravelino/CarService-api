using MediatR;

namespace Application.Features.Jobs.SoftDeleteJob;

public record SoftDeleteJobCommand(int JobId) : IRequest;