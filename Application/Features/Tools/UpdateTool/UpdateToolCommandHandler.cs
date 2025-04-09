using Application.Features.Tools.UpdateTool;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Tools.UpdateTool;

public class UpdateToolCommandHandler : IRequestHandler<UpdateToolCommand>
{
    private readonly IToolRepository _toolRepository;

    public UpdateToolCommandHandler(IToolRepository toolRepository)
    {
        _toolRepository = toolRepository;
    }
    
    public async Task Handle(UpdateToolCommand request, CancellationToken cancellationToken)
    {
        var service = await _toolRepository.GetByIdAsync(request.Id);
        if (service == null)
        {
            throw new Exception("Tool not found");
        }
        
        if(request.Description is not null) service.Description = request.Description;
        if(request.SerialNumber.HasValue) service.SerialNumber = request.SerialNumber.Value;
        if(request.Name is not null) service.Name = request.Name;
        
        await _toolRepository.Update(service);
        await _toolRepository.SaveChangesAsync();
    }
}