using Application.Models;
using MediatR;

namespace Application.Features.Tools.CreateTool;

public record CreateToolCommand(string Name, string Description, int SerialNumber): IRequest<int>;