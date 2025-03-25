using MediatR;

namespace Application.Features.Tools.SoftDeleteTool;

public record SoftDeleteToolCommand(int Id) : IRequest;