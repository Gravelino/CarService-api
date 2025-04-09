using Application.Interfaces;
using MediatR;

namespace Application.Features.Services.UpdateService;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IServiceRepository _serviceRepository;

    public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
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
        await _serviceRepository.SaveChangesAsync();
    }
}