using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class JobRepository : SoftDeletableRepository<Job>, IJobRepository
{
    public JobRepository(CarServiceDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Job>> GetJobsWithSchedulesByVisitIdAsync(int visitId)
    {
        var jobs = await _context.Jobs
            .Include(j => j.JobSchedule)
            .Where(j => j.VisitId == visitId)
            .ToListAsync();
        
        return jobs;
    }

    public async Task<IEnumerable<Job>> GetAllJobsWithSchedules()
    {
        var jobs = await _context.Jobs.Include(j => j.JobSchedule).ToListAsync();
        
        return jobs;
    }
}