using MediatR;

namespace Application.Features.Workers.RestoreWorker;

public record RestoreWorkerCommand(int Id): IRequest;