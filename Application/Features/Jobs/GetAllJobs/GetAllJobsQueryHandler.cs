using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Jobs.GetAllJobs;

public class GetAllJobsQueryHandler : IRequestHandler<GetAllJobsQuery, PagedResult<Job>>
{
    private readonly IJobRepository _repository;

    public GetAllJobsQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<PagedResult<Job>> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAllAsync();

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
        
        return new PagedResult<Job>(items, total);
    }
}