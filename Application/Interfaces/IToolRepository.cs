using Application.Models;

namespace Application.Interfaces;

public interface IToolRepository : ISoftDeletableRepository<Tool>
{
    Task<IEnumerable<Tool>> GetToolsForServiceAsync(int serviceId);
    Task<Tool?> GetToolBySerialNumberAsync(int serialNumber);
}