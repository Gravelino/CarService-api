using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.JobSchedules.GetAllJobSchedules;

public class GetAllJobSchedulesQueryHandler : IRequestHandler<GetAllJobSchedulesQuery, PagedResult<JobSchedule>>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;

    public GetAllJobSchedulesQueryHandler(IJobScheduleRepository jobScheduleRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
    }
    
    public async Task<PagedResult<JobSchedule>> Handle(GetAllJobSchedulesQuery request, CancellationToken cancellationToken)
    {
        var query = _jobScheduleRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.SortField))
        {
            query = request.SortOrder == "DESC" 
                ? query.OrderByDescending(p => EF.Property<object>(p, request.SortField))
                : query.OrderBy(p => EF.Property<object>(p, request.SortField));
        }
        
        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        
        return new PagedResult<JobSchedule>(items, total);
    }
}