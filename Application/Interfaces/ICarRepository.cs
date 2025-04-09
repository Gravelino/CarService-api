using Application.Models;

namespace Application.Interfaces;

public interface ICarRepository : ISoftDeletableRepository<Car>
{
    Task<IEnumerable<Car>> GetCarsByCustomerIdAsync(int customerId);
    Task<Car?> GetCarWithVisitHistoryAsync(int carId);
    Task<bool> IsLicensePlateUniqueAsync(string licensePlate, int? excludedId = null);
}