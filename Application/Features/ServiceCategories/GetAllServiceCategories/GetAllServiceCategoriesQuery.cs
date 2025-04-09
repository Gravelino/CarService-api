using Application.Models;
using MediatR;

namespace Application.Features.Services.GetAllServices;

public class GetAllServiceCategoriesQuery : IRequest<PagedResult<ServiceCategory>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public string? NameFilter { get; set; }
}