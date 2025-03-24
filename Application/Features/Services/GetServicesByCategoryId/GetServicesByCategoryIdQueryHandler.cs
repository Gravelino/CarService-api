using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Services.GetServicesByCategory;

public class GetServicesByCategoryIdQueryHandler : IRequestHandler<GetServicesByCategoryIdQuery, IEnumerable<Service>>
{
    private readonly IServiceRepository _repository;

    public GetServicesByCategoryIdQueryHandler(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Service>> Handle(GetServicesByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var services = await _repository.GetServicesByCategoryIdAsync(request.Id);
        return services.Where(s => s.DeletedAt == null);
    }
}