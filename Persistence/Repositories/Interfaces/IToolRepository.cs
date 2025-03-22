using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IToolRepository : ISoftDeletableRepository<Tool>
{
    Task<IEnumerable<Tool>> GetToolsForServiceAsync(int serviceId);
    Task<Tool> GetToolBySerialNumberAsync(int serialNumber);
}