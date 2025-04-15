using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetAllWorkers;

public class GetAllWorkersQuery : IRequest<PagedResult<Worker>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public string? NameFilter { get; set; }
    public string? SpecializationFilter { get; set; }
    public bool? IsActiveFilter { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}