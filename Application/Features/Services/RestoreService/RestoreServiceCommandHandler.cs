using Application.Interfaces;
using MediatR;

namespace Application.Features.Services.RestoreService;

public class RestoreServiceCommandHandler : IRequestHandler<RestoreServiceCommand>
{
    private readonly IServiceRepository _serviceRepository;

    public RestoreServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task Handle(RestoreServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetByIdAsync(request.Id);
        if (service == null)
        {
            throw new Exception("Service not found");
        }
        
        await _serviceRepository.RestoreAsync(service.Id);
    }
}