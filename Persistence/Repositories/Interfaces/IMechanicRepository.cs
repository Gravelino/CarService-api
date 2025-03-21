using Application.Models;

namespace Persistence.Repositories;

public interface IMechanicRepository : ISoftDeletableRepository<Mechanic>
{
    Task<Mechanic> GetMechanicWithScheduledVisitsByIdAsync(int mechanicId);
    Task<IEnumerable<Mechanic>> GetAvailableMechanicsAsync();
}