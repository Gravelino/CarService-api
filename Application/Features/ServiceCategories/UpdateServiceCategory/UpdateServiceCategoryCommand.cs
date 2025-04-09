using MediatR;

namespace Application.Features.ServiceCategories.UpdateServiceCategory;

public record UpdateServiceCategoryCommand(int Id, string? CategoryName, string? Description): IRequest;