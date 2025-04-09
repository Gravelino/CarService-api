using Application.Interfaces;
using MediatR;

namespace Application.Features.ServiceCategories.UpdateServiceCategory;

public class UpdateServiceCategoryCommandHandler : IRequestHandler<UpdateServiceCategoryCommand>
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public UpdateServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }
    
    public async Task Handle(UpdateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepository.GetByIdAsync(request.Id);
        if (serviceCategory == null)
        {
            throw new Exception("Service not found");
        }
        
        if(request.Description is not null) serviceCategory.Description = request.Description;
        if(request.CategoryName is not null) serviceCategory.CategoryName = request.CategoryName;
        
        await _serviceCategoryRepository.Update(serviceCategory);
        await _serviceCategoryRepository.SaveChangesAsync();
    }
}