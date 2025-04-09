using Application.Models;
using MediatR;

namespace Application.Features.ServiceCategories.GetServiceCategoryById;

public record GetServiceCategoryByIdQuery(int Id) : IRequest<ServiceCategory?>;