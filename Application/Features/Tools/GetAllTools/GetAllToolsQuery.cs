using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetAllTools;

public class GetAllToolsQuery : IRequest<IEnumerable<Tool>>
{
    
}