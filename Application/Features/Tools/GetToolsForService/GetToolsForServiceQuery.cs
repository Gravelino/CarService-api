using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetToolsForService;

public class GetToolsForServiceQuery : IRequest<IEnumerable<Tool>>
{
    public int ServiceId { get; set; }
}