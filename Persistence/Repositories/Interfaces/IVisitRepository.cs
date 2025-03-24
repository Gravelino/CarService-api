using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IVisitRepository : ISoftDeletableRepository<Visit>
{
    Task<Visit?> GetVisitWithServicesAndWorkersByIdAsync(int visitId);
    Task<IEnumerable<Visit>> GetVisitsByCustomerIdAsync(int customerId);
    Task<IEnumerable<Visit>> GetVisitsWithPaymentsAsync();
}