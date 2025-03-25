using Application.Features.Tools.SoftDeleteTool;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Tools.SoftDeleteTool;

public class SoftDeleteToolCommandHandler : IRequestHandler<SoftDeleteToolCommand>
{
    private readonly IToolRepository _toolRepository;

    public SoftDeleteToolCommandHandler(IToolRepository toolRepository)
    {
        _toolRepository = toolRepository;
    }
    
    public async Task Handle(SoftDeleteToolCommand request, CancellationToken cancellationToken)
    {
        var tool = await _toolRepository.GetByIdAsync(request.Id);
        if (tool == null)
        {
            throw new Exception("Tool not found");
        }
        
        await _toolRepository.SoftDeleteAsync(tool.Id);
    }
}