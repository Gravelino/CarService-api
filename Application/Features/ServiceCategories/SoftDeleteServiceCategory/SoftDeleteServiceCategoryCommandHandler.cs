using Application.Interfaces;
using MediatR;

namespace Application.Features.ServiceCategories.SoftDeleteServiceCategory;

public class SoftDeleteServiceCategoryCommandHandler : IRequestHandler<SoftDeleteServiceCategoryCommand>
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public SoftDeleteServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }
    
    public async Task Handle(SoftDeleteServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(request.Id);
        if (serviceCategory == null)
        {
            throw new Exception("Service Category not found");
        }
        
        await _serviceCategoryRepository.SoftDeleteAsync(serviceCategory.Id);
    }
}