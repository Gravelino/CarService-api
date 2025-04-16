using Application.Models;
using MediatR;

namespace Application.Features.Tools.GetAllTools;

public class GetAllToolsQuery : IRequest<PagedResult<Tool>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public string? NameFilter { get; set; }
    public string? DescriptionFilter { get; set; }
}