using Application.Models;

namespace Application.Interfaces;

public interface IServiceToolRepository : ISoftDeletableRepository<ServiceTool>
{
    Task DeleteByServiceIdAsync(int serviceId);
    Task DeleteByServiceAndToolIdAsync(int serviceId, int toolId);
    Task<IEnumerable<int>> GetToolIdsByServiceIdAsync(int serviceId);
}