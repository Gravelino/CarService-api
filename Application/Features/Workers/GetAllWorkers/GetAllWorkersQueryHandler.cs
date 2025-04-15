using Application.Interfaces;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Workers.GetAllWorkers
{
    public class GetAllWorkersQueryHandler : IRequestHandler<GetAllWorkersQuery, PagedResult<Worker>>
    {
        private readonly IWorkerRepository _repository;

        public GetAllWorkersQueryHandler(IWorkerRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<Worker>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetAllAsync();
            
            if (!string.IsNullOrEmpty(request.NameFilter))
            {
                var nameLower = request.NameFilter.ToLower();
                query = query.Where(e => (e.FirstName != null && e.FirstName.ToLower().Contains(nameLower)) ||
                                         (e.LastName != null && e.LastName.ToLower().Contains(nameLower)));
            }

            if (!string.IsNullOrEmpty(request.SpecializationFilter))
            {
                var specializationLower = request.SpecializationFilter.ToLower();
                query = query.Where(e => e.Specialization != null && e.Specialization.ToLower().Contains(specializationLower));
            }

            if (request.IsActiveFilter.HasValue)
            {
                query = query.Where(e => e.IsActive == request.IsActiveFilter.Value);
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                 query = query.Where(c => c.Email != null && c.Email.Contains(request.Email));
            }

            if (!string.IsNullOrEmpty(request.Phone))
            {
                 query = query.Where(c => c.Phone != null && c.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrEmpty(request.SortField))
            {
                bool descending = request.SortOrder?.Equals("DESC", StringComparison.OrdinalIgnoreCase) ?? false;

                if (request.SortField.Equals("IsActive", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.IsActive) : query.OrderBy(p => p.IsActive);
                }
                else if (request.SortField.Equals("LastName", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.LastName) : query.OrderBy(p => p.LastName);
                }
                else if (request.SortField.Equals("FirstName", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.FirstName) : query.OrderBy(p => p.FirstName);
                }
                else if (request.SortField.Equals("HireDate", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.HireDate) : query.OrderBy(p => p.HireDate);
                }
                else if (request.SortField.Equals("Salary", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.Salary) : query.OrderBy(p => p.Salary);
                }
                else if (request.SortField.Equals("Specialization", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.Specialization) : query.OrderBy(p => p.Specialization);
                }
                else if (request.SortField.Equals("Email", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.Email) : query.OrderBy(p => p.Email);
                }
                else if (request.SortField.Equals("Phone", StringComparison.OrdinalIgnoreCase))
                {
                    query = descending ? query.OrderByDescending(p => p.Phone) : query.OrderBy(p => p.Phone);
                }
                else
                {
                    query = descending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                }
            }
            else
            {
                query = query.OrderBy(p => p.Id);
            }

            var total = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedResult<Worker>(items, total);
        }
    }
}