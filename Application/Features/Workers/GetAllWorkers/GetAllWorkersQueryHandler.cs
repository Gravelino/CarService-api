using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Workers.GetAllWorkers;

public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery, PagedResult<Worker>>
{
    private readonly IWorkerRepository _repository;

    public GetAllWorkersQueryHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Worker>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
    {
        var query =  _repository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.FirstName.Contains(request.NameFilter));
        }

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
        
        return new PagedResult<Worker>(items, total);
    }
}