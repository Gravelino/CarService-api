using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Services.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IServiceToolRepository _serviceToolRepository;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository, IServiceToolRepository serviceToolRepository)
    {
        _serviceRepository = serviceRepository;
        _serviceToolRepository = serviceToolRepository;
    }
    
    public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetByIdAsync(request.Id);
        if (service == null)
        {
            throw new Exception("Service not found");
        }
        
        if(request.BasePrice.HasValue) service.BasePrice = request.BasePrice.Value;
        if(request.Description is not null) service.Description = request.Description;
        if(request.Duration.HasValue) service.Duration = request.Duration.Value;
        if(request.ServiceName is not null) service.ServiceName = request.ServiceName;
        if(request.ServiceCategoryId.HasValue) service.ServiceCategoryId = request.ServiceCategoryId.Value;
        
        await _serviceRepository.Update(service);
        await _serviceToolRepository.DeleteByServiceIdAsync(service.Id);
        
        if (request.ToolIds.Any())
        {
            foreach (var toolId in request.ToolIds)
            {
                var serviceTool = new ServiceTool
                {
                    ServicesId = service.Id,
                    ToolsId = toolId
                };
                
                await _serviceToolRepository.AddAsync(serviceTool);
            }
        }
        
        await _serviceToolRepository.SaveChangesAsync();
        
        return Unit.Value;

    }
}