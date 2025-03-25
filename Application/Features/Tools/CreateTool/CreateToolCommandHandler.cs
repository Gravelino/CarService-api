using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Tools.CreateTool;

public class CreateToolCommandHandler : IRequestHandler<CreateToolCommand, int>
{
    private readonly IToolRepository _toolRepository;

    public CreateToolCommandHandler(IToolRepository toolRepository)
    {
        _toolRepository = toolRepository;
    }
    
    public async Task<int> Handle(CreateToolCommand request, CancellationToken cancellationToken)
    {
        var tool = new Tool
        {
            Name = request.Name,
            Description = request.Description,
            SerialNumber = request.SerialNumber,
        };
        
        await _toolRepository.AddAsync(tool);
        await _toolRepository.SaveChangesAsync();
        
        return tool.Id;
    }
}