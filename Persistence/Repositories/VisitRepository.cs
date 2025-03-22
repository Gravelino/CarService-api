using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class VisitRepository: SoftDeletableRepository<Visit>, IVisitRepository
{
    public VisitRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<Visit> GetVisitWithServicesAndWorkersByIdAsync(int visitId)
    {
        return await _dbSet
            .Include(v => v.VisitServices)
            .ThenInclude(vs => vs.Service)
            .Include(v => v.VisitServiceSchedules)
            .ThenInclude(vss => vss.Worker)
            .FirstOrDefaultAsync(v => v.Id == visitId);
    }

    public async Task<IEnumerable<Visit>> GetVisitsByCustomerIdAsync(int customerId)
    {
        return await _dbSet
            .Where(v => v.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Visit>> GetVisitsWithPaymentsAsync()
    {
        return await _dbSet
            .Include(v => v.Payments)
            .ToListAsync();
    }
}