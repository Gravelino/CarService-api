using MediatR;

namespace Application.Features.Workers.SoftDeleteWorker;

public record SoftDeleteWorkerCommand(int Id) : IRequest;