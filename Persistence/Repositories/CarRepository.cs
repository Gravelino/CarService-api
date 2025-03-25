using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class CarRepository : SoftDeletableRepository<Car>, ICarRepository
{
    public CarRepository(CarServiceDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Car>> GetCarsByCustomerIdAsync(int customerId)
    {
        return await _dbSet
            .Where(c => c.CustomerId == customerId && c.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<Car?> GetCarWithVisitHistoryAsync(int carId)
    {
        return await _dbSet
            .Include(c => c.Visits)
            .FirstOrDefaultAsync(c => c.Id == carId);
    }

    public async Task<bool> IsLicensePlateUniqueAsync(string licensePlate, int? excludedId = null)
    {
        return !await _context.Cars
            .Where(c => c.DeletedAt == null)
            .Where(c => c.LicensePlate == licensePlate)
            .Where(c => excludedId == null || c.Id != excludedId.Value)
            .AnyAsync();
    }

    public override async Task AddAsync(Car car)
    {
        if (!await IsLicensePlateUniqueAsync(car.LicensePlate))
            throw new Exception("A car with this license plate already exists");

        await base.AddAsync(car);
    }

    public override async Task Update(Car car)
    {
        if (!await IsLicensePlateUniqueAsync(car.LicensePlate, car.Id))
            throw new Exception("A car with this license plate already exists");

        await base.Update(car);
    }

}