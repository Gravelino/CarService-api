using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Services.SoftDeleteService;

public class SoftDeleteServiceCommandHandler : IRequestHandler<SoftDeleteServiceCommand>
{
    private readonly IServiceRepository _serviceRepository;

    public SoftDeleteServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task Handle(SoftDeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetByIdAsync(request.Id);
        if (service == null)
        {
            throw new Exception("Service not found");
        }
        
        await _serviceRepository.SoftDeleteAsync(service.Id);
    }
}