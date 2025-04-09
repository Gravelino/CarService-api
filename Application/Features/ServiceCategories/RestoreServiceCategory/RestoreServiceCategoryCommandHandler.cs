using Application.Interfaces;
using MediatR;

namespace Application.Features.ServiceCategories.RestoreServiceCategory;

public class RestoreServiceCategoryCommandHandler : IRequestHandler<RestoreServiceCategoryCommand>
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public RestoreServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }
    
    public async Task Handle(RestoreServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(request.Id);
        if (serviceCategory == null)
        {
            throw new Exception("Service Category not found");
        }
        
        await _serviceCategoryRepository.RestoreAsync(serviceCategory.Id);
    }
}