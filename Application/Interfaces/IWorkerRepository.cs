using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IWorkerRepository : ISoftDeletableRepository<Worker>
{
    Task<Worker?> GetWorkerWithScheduledVisitsByIdAsync(int workerId);
    Task<IEnumerable<Worker>> GetAvailableWorkersAsync();
}