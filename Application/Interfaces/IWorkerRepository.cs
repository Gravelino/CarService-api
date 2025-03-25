using Application.Models;

namespace Application.Interfaces;

public interface IWorkerRepository : ISoftDeletableRepository<Worker>
{
    Task<Worker?> GetWorkerWithScheduledVisitsByIdAsync(int workerId);
    Task<IEnumerable<Worker>> GetAvailableWorkersAsync();
}