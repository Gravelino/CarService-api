using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class VisitRepository: SoftDeletableRepository<Visit>, IVisitRepository
{
    public VisitRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<Visit?> GetVisitWithServicesAndWorkersByIdAsync(int visitId)
    {
        var visit = await _dbSet
            .Include(v => v.Jobs)
            .ThenInclude(vs => vs.Service)
            .ThenInclude(s => s.WorkerServices)
            .ThenInclude(ws => ws.Worker)
            .FirstOrDefaultAsync(v => v.Id == visitId);
        
         return visit;
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