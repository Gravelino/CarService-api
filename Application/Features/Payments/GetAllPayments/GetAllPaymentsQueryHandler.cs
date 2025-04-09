using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Payments.GetAllPayments;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, PagedResult<Payment>>
{
    private readonly IPaymentRepository _repository;

    public GetAllPaymentsQueryHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Payment>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var query =  _repository.GetAllAsync();

        if (!string.IsNullOrEmpty(request.NameFilter))
        {
            query = query.Where(e => e.Status.Contains(request.NameFilter));
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
        
        return new PagedResult<Payment>(items, total);
    }
}