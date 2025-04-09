using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.ServiceCategories.GetServiceCategoryById;

public class GetServiceCategoryByIdQueryHandler : IRequestHandler<GetServiceCategoryByIdQuery, ServiceCategory?>
{
    private readonly IServiceCategoryRepository _repository;

    public GetServiceCategoryByIdQueryHandler(IServiceCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceCategory?> Handle(GetServiceCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var serviceCategory = await _repository.GetByIdAsync(request.Id);
        return serviceCategory;
    }
}