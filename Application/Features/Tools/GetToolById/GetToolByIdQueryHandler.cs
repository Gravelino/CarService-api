using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetToolById;

public class GetToolByIdQueryHandler : IRequestHandler<GetToolByIdQuery, Tool?>
{
    private readonly IToolRepository _repository;

    public GetToolByIdQueryHandler(IToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<Tool?> Handle(GetToolByIdQuery request, CancellationToken cancellationToken)
    {
        var tool = await _repository.GetByIdAsync(request.ToolId);
        return tool;
    }
}