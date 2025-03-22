using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IWorkerRepository : ISoftDeletableRepository<Worker>
{
    Task<Worker> GetWorkerWithScheduledVisitsByIdAsync(int WorkerId);
    Task<IEnumerable<Worker>> GetAvailableWorkersAsync();
}