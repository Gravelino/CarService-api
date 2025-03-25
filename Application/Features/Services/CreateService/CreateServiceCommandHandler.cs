using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Services.CreateService;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
{
    private readonly IServiceRepository _serviceRepository;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
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
        
        return service.Id;
    }
}