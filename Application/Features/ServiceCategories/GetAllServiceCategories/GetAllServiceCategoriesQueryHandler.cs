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
        var query = _serviceCategoriesRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.CategoryName.Contains(request.NameFilter));
        }
        
        if (!string.IsNullOrEmpty(request.DescriptionFilter))
        {
            query = query.Where(e => e.Description.Contains(request.DescriptionFilter));
        }

        if (!string.IsNullOrEmpty(request.SortField))
        {
            try 
            {
                string propertyName = request.SortField;
                
                var propertyInfo = typeof(ServiceCategory).GetProperty(propertyName, 
                    System.Reflection.BindingFlags.IgnoreCase | 
                    System.Reflection.BindingFlags.Public | 
                    System.Reflection.BindingFlags.Instance);
                    
                if (propertyInfo != null) 
                {
                    propertyName = propertyInfo.Name;
                    
                    query = request.SortOrder.ToUpper() == "DESC" 
                        ? query.OrderByDescending(p => EF.Property<object>(p, propertyName))
                        : query.OrderBy(p => EF.Property<object>(p, propertyName));
                }
                else 
                {
                    query = query.OrderBy(p => p.Id);
                }
            }
            catch (Exception ex)
            {
                query = query.OrderBy(p => p.Id);
            }
        }
        
        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        
        return new PagedResult<ServiceCategory>(items, total);
    }
}