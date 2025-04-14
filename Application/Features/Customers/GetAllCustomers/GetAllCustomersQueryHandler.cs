using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customers.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResult<Customer>>
{
    private readonly ICustomerRepository _repository;

    public GetAllCustomersQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }


    public async Task<PagedResult<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameLike))
        {
            query = query.Where(c => 
                c.FirstName.Contains(request.NameLike) ||
                c.LastName.Contains(request.NameLike));
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            query = query.Where(c => c.Email.Contains(request.Email));
        }

        if (!string.IsNullOrEmpty(request.Phone))
        {
            query = query.Where(c => c.Phone.Contains(request.Phone));
        }

        try
        {
            var validSortFields = new[] { "Id", "FirstName", "LastName", "Email", "Phone", "RegistrationDate" };
            var sortField = validSortFields.Contains(request.SortField) ? request.SortField : "Id";
        
            query = request.SortOrder == "DESC" 
                ? query.OrderByDescending(p => EF.Property<object>(p, sortField))
                : query.OrderBy(p => EF.Property<object>(p, sortField));
        }
        catch
        {
            query = query.OrderBy(p => p.Id);
        }

        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
    
        return new PagedResult<Customer>(items, total);
    }
}