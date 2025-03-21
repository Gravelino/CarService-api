using Application.Models;

namespace Persistence.Repositories;

public interface ICarRepository : ISoftDeletableRepository<Car>
{
    Task<IEnumerable<Car>> GetCarsByCustomerIdAsync(int customerId);
    Task<Car> GetCarWithVisitHistoryAsync(int carId);
}