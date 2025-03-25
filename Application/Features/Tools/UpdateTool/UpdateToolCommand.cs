using MediatR;

namespace Application.Features.Tools.UpdateTool;

public record UpdateToolCommand(int Id, string? Name, string? Description, int? SerialNumber): IRequest;