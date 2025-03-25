using MediatR;

namespace Application.Features.Tools.RestoreTool;

public record RestoreToolCommand(int Id): IRequest;