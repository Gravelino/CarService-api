using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Services.GetMostPopularServices;

public class GetMostPopularServicesQueryHandler : IRequestHandler<GetMostPopularServicesQuery, IEnumerable<Service>>
{
    private readonly IServiceRepository _repository;

    public GetMostPopularServicesQueryHandler(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Service>> Handle(GetMostPopularServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetMostPopularServicesAsync(request.Limit);
        return services.Where(s => s.DeletedAt == null);
    }
}