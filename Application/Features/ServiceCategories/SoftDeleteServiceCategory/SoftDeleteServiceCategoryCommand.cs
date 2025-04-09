using MediatR;

namespace Application.Features.ServiceCategories.SoftDeleteServiceCategory;

public record SoftDeleteServiceCategoryCommand(int Id) : IRequest;