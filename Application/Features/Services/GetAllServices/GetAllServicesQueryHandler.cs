using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Services.GetAllServices;

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, PagedResult<Service>>
{
    private readonly IServiceRepository _serviceRepository;

    public GetAllServicesQueryHandler(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<PagedResult<Service>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        var query = _serviceRepository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.ServiceName.Contains(request.NameFilter));
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
        
                var propertyInfo = typeof(Service).GetProperty(propertyName, 
                    System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        
                if (propertyInfo != null) {
                    propertyName = propertyInfo.Name;
            
                    query = request.SortOrder.ToUpper() == "DESC" 
                        ? query.OrderByDescending(p => EF.Property<object>(p, propertyName))
                        : query.OrderBy(p => EF.Property<object>(p, propertyName));
                }
                else {
                    Console.WriteLine($"Властивість {request.SortField} не знайдена, використовую Id");
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
        
        return new PagedResult<Service>(items, total);
    }
}