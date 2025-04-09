using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

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

    public async Task<bool> IsEmailUniqueAsync(string email, int? excludedId = null)
    {
        return !await _context.Customers
            .Where(c => c.DeletedAt == null)
            .Where(c => c.Email == email)
            .Where(c => excludedId == null || c.Id != excludedId.Value)
            .AnyAsync();
    }

    public async Task<bool> IsPhoneUniqueAsync(string phone, int? excludedId = null)
    {
        return !await _context.Customers
            .Where(c => c.DeletedAt == null)
            .Where(c => c.Phone == phone)
            .Where(c => excludedId == null || c.Id != excludedId.Value)
            .AnyAsync();
    }
    
    public override async Task AddAsync(Customer customer)
    {
        if (!await IsEmailUniqueAsync(customer.Email))
            throw new Exception("A user with this email already exists");

        if (!await IsPhoneUniqueAsync(customer.Phone))
            throw new Exception("A user with this phone already exists");

        await base.AddAsync(customer);
    }

    public override async Task Update(Customer customer)
    {
        if (!await IsEmailUniqueAsync(customer.Email, customer.Id))
            throw new Exception("A user with this email already exists");

        if (!await IsPhoneUniqueAsync(customer.Phone, customer.Id))
            throw new Exception("A user with this phone already exists");

        await base.Update(customer);
    }
}