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
        
        if(request.BasePrice is not null) service.BasePrice = (decimal)request.BasePrice;
        if(request.Description is not null) service.Description = request.Description;
        if(request.Duration is not null) service.Duration = (int)request.Duration;
        if(request.ServiceName is not null) service.ServiceName = request.ServiceName;
        if(request.ServiceCategoryId is not null) service.ServiceCategoryId = (int)request.ServiceCategoryId;
        
        _serviceRepository.Update(service);
        await _serviceRepository.SaveChangesAsync();
    }
}