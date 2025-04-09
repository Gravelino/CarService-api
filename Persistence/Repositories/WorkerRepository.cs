using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class WorkerRepository : SoftDeletableRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<Worker?> GetWorkerWithScheduledVisitsByIdAsync(int workerId)
    {
        var worker = await _dbSet
            .Include(w => w.JobSchedules)
            .ThenInclude(vss => vss.Job)
            .ThenInclude(vs => vs.Visit.DeletedAt == null)
            .FirstOrDefaultAsync(m => m.Id == workerId && m.DeletedAt == null);

        return worker;
    }

    public async Task<IEnumerable<Worker>> GetAvailableWorkersAsync()
    {
        return await _dbSet
            .Where(m => m.DeletedAt == null && !m.IsActive)
            .ToListAsync();
    }
}