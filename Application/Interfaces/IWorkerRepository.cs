using Application.DTOs;
using Application.Models;

namespace Application.Interfaces;

public interface IWorkerRepository : ISoftDeletableRepository<Worker>
{
    Task<Worker?> GetWorkerWithScheduledVisitsByIdAsync(int workerId);
    Task<IEnumerable<Worker>> GetAvailableWorkersAsync();
    Task<bool> IsWorkerAvailableByIdAsync(int workerId, DateTime proposedStart, DateTime proposedEnd);

    Task<IEnumerable<AvailableSlotDto>> FindAvailableSlotsForService(int serviceId, DateTime startDate,
        DateTime endDate);
}