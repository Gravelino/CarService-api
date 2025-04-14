using Application.Models;
using MediatR;

namespace Application.Features.Customers.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<PagedResult<Customer>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortField { get; set; } = "Id";
    public string SortOrder { get; set; } = "ASC";
    public string? NameLike { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}