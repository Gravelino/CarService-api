using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tools.GetAllTools;

public class GetAllToolsQueryHandler : IRequestHandler<GetAllToolsQuery, PagedResult<Tool>>
{
    private readonly IToolRepository _repository;

    public GetAllToolsQueryHandler(IToolRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Tool>> Handle(GetAllToolsQuery request, CancellationToken cancellationToken)
    {
        var query =  _repository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.Name.Contains(request.NameFilter));
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
        
        return new PagedResult<Tool>(items, total);
    }
}