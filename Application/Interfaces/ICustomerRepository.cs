using Application.Models;

namespace Application.Interfaces;

public interface ICustomerRepository : ISoftDeletableRepository<Customer>
{
    Task<Customer?> GetCustomerWithCarsByIdAsync(int customerId);
    Task<IEnumerable<Customer>> GetCustomersWithVisitsAsync();
    Task<IEnumerable<Customer>> GetTopSpendingCustomersAsync(int limit);
    Task<bool> IsEmailUniqueAsync(string email, int? excludedId = null);

    Task<bool> IsPhoneUniqueAsync(string phone, int? excludedId = null);

}