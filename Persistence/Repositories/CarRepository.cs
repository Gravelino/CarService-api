using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

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
}