using MediatR;

namespace Application.Features.ServiceCategories.RestoreServiceCategory;

public record RestoreServiceCategoryCommand(int Id): IRequest;