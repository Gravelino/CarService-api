using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class CustomerRepository : SoftDeletableRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(CarServiceDbContext context) : base(context)
    {
    }

    public async Task<Customer?> GetCustomerWithCarsByIdAsync(int customerId)
    {
        return await _dbSet
            .Include(c => c.Cars)
            .FirstOrDefaultAsync(c => c.Id == customerId && c.DeletedAt == null);
    }

    public async Task<IEnumerable<Customer>> GetCustomersWithVisitsAsync()
    {
        return await _dbSet
            .Include(c => c.Visits)
            .Where(c => c.DeletedAt == null && c.Visits.Any())
            .ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetTopSpendingCustomersAsync(int limit)
    {
        return await _dbSet
            .Include(c => c.Visits)
            .Where(c => c.DeletedAt == null)
            .OrderByDescending(c => c.Visits.Where(v => v.DeletedAt == null).Sum(v => v.TotalPrice))
            .Take(limit)
            .ToListAsync();
    }
}