using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface IServiceRepository : ISoftDeletableRepository<Service>
{
    Task<IEnumerable<Service>> GetServicesByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Service>> GetMostPopularServicesAsync(int limit);
}