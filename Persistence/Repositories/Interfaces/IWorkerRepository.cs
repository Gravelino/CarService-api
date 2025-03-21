using Application.Models;

namespace Persistence.Repositories;

public interface IWorkerRepository : ISoftDeletableRepository<Worker>
{
    Task<Worker> GetWorkerWithScheduledVisitsByIdAsync(int WorkerId);
    Task<IEnumerable<Worker>> GetAvailableWorkersAsync();
}