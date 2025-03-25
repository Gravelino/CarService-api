using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Tools.RestoreTool;

public class RestoreToolCommandHandler : IRequestHandler<RestoreToolCommand>
{
    private readonly IToolRepository _toolRepository;

    public RestoreToolCommandHandler(IToolRepository toolRepository)
    {
        _toolRepository = toolRepository;
    }
    
    public async Task Handle(RestoreToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _toolRepository.GetByIdAsync(request.Id);
        if (tool == null)
        {
            throw new Exception("Tool not found");
        }
        
        await _toolRepository.RestoreAsync(tool.Id);
    }
}