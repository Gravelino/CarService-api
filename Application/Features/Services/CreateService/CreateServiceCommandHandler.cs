using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Services.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IServiceToolRepository _serviceToolRepository;


    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IServiceToolRepository serviceToolRepository)
    {
        _serviceRepository = serviceRepository;
        _serviceToolRepository = serviceToolRepository;
    }
    
    public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            ServiceName = request.ServiceName,
            Description = request.Description,
            BasePrice = request.BasePrice,
            Duration = request.Duration,
            ServiceCategoryId = request.ServiceCategoryId,
        };
        
        await _serviceRepository.AddAsync(service);
        await _serviceRepository.SaveChangesAsync();
        
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
            await _serviceToolRepository.SaveChangesAsync();
        }
        
        return service.Id;
    }
}