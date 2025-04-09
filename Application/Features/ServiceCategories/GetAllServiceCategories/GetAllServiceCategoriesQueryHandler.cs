using Application.Features.Services.GetAllServices;
using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ServiceCategories.GetAllServiceCategories;

public class GetAllServiceCategoriesQueryHandler : IRequestHandler<GetAllServiceCategoriesQuery, PagedResult<ServiceCategory>>
{
    private readonly IServiceCategoryRepository _serviceCategoriesRepository;

    public GetAllServiceCategoriesQueryHandler(IServiceCategoryRepository serviceCategoriesRepository)
    {
        _serviceCategoriesRepository = serviceCategoriesRepository;
    }

    public async Task<PagedResult<ServiceCategory>> Handle(GetAllServiceCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query =  _serviceCategoriesRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.CategoryName.Contains(request.NameFilter));
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
        
        return new PagedResult<ServiceCategory>(items, total);
    }
}