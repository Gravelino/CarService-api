using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetAllJobSchedules;

public class GetAllJobSchedulesQuery : IRequest<PagedResult<JobSchedule>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortField { get; set; }
    public string? SortOrder { get; set; }
    public string? NameFilter { get; set; }
}