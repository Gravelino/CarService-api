using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetAllTools;

public class GetAllToolsQueryHandler : IRequestHandler<GetAllToolsQuery, IEnumerable<Tool>>
{
    private readonly IToolRepository _repository;

    public GetAllToolsQueryHandler(IToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tool>> Handle(GetAllToolsQuery request, CancellationToken cancellationToken)
    {
        var tools = await _repository.GetAllAsync();
        return tools.Where(t => t.DeletedAt == null);
    }
}