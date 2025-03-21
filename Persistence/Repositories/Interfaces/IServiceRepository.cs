using Application.Models;

namespace Persistence.Repositories;

public interface IServiceRepository : ISoftDeletableRepository<Visit>
{
    Task<IEnumerable<Service>> GetServicesByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Service>> GetMostPopularServicesAsync(int limit);
}