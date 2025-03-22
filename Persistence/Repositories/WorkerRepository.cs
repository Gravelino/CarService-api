using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Interfaces;

namespace Persistence.Repositories;

public class WorkerRepository : SoftDeletableRepository<Worker>, IWorkerRepository
{
    public WorkerRepository(CarServiceDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<Worker> GetWorkerWithScheduledVisitsByIdAsync(int workerId)
    {
        var worker = await _dbSet
            .FirstOrDefaultAsync(m => m.Id == workerId && m.DeletedAt == null);

        if (worker != null)
        {
            var schedules = await _context.VisitServiceSchedules
                .Include(vss => vss.VisitService)
                .ThenInclude(vs => vs.Visit)
                .Where(vss => vss.WorkerId == workerId && vss.VisitService.Visit.DeletedAt == null)
                .ToListAsync();
        }

        return worker;
    }

    public async Task<IEnumerable<Worker>> GetAvailableWorkersAsync()
    {
        return await _dbSet
            .Where(m => m.DeletedAt == null && !m.IsActive)
            .ToListAsync();
    }
}