using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetToolById;

public class GetToolByIdQuery : IRequest<Tool?>
{
    public int ToolId { get; set; }
}