using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface ICustomerRepository : ISoftDeletableRepository<Customer>
{
    Task<Customer?> GetCustomerWithCarsByIdAsync(int customerId);
    Task<IEnumerable<Customer>> GetCustomersWithVisitsAsync();
    Task<IEnumerable<Customer>> GetTopSpendingCustomersAsync(int limit);
}