using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Services.GetServiceById;

public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, Service?>
{
    private readonly IServiceRepository _repository;

    public GetServiceByIdQueryHandler(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Service?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var service = await _repository.GetByIdAsync(request.ServiceId);
        return service;
    }
}