using Application.Models;

namespace Application.Interfaces;

public interface IServiceRepository : ISoftDeletableRepository<Service>
{
    Task<IEnumerable<Service>> GetServicesByCategoryIdAsync(int categoryId);
    Task<IEnumerable<Service>> GetMostPopularServicesAsync(int limit);
}