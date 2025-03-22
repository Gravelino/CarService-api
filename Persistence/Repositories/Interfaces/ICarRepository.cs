using Application.Models;

namespace Persistence.Repositories.Interfaces;

public interface ICarRepository : ISoftDeletableRepository<Car>
{
    Task<IEnumerable<Car>> GetCarsByCustomerIdAsync(int customerId);
    Task<Car> GetCarWithVisitHistoryAsync(int carId);
}