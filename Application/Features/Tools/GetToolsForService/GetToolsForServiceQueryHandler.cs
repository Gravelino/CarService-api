using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Tools.GetToolsForService;

public class GetToolsForServiceQueryHandler : IRequestHandler<GetToolsForServiceQuery, IEnumerable<Tool>>
{
    private readonly IToolRepository _repository;

    public GetToolsForServiceQueryHandler(IToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tool>> Handle(GetToolsForServiceQuery request, CancellationToken cancellationToken)
    {
        var tools = await _repository.GetToolsForServiceAsync(request.ServiceId);
        return tools.Where(t => t.DeletedAt == null);
    }
}