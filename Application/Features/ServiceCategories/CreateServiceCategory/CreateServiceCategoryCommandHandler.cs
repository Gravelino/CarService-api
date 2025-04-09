using Application.Features.Services.CreateService;
using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.ServiceCategories.CreateServiceCategory;

public class CreateServiceCategoryCommandHandler : IRequestHandler<CreateServiceCategoryCommand, int>
{
    private readonly IServiceCategoryRepository _serviceCategoryRepository;

    public CreateServiceCategoryCommandHandler(IServiceCategoryRepository serviceCategoryRepository)
    {
        _serviceCategoryRepository = serviceCategoryRepository;
    }
    
    public async Task<int> Handle(CreateServiceCategoryCommand request, CancellationToken cancellationToken)
    {
        var serviceCategory = new ServiceCategory
        {
            CategoryName = request.CategoryName,
            Description = request.Description,
        };
        
        await _serviceCategoryRepository.AddAsync(serviceCategory);
        await _serviceCategoryRepository.SaveChangesAsync();
        
        return serviceCategory.Id;
    }
}