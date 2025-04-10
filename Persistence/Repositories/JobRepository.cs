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

    public async Task<Job?> GetJobWithScheduleByIdAsync(int jobId)
    {
        var job = await _context.Jobs
            .Include(j => j.JobSchedule)
            .FirstOrDefaultAsync(j => j.Id == jobId);
        
        return job;
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

    public override async Task SoftDeleteAsync(int jobId)
    {
        var job = await GetJobWithScheduleByIdAsync(jobId);
        if (job == null)
        {
            return;
        }

        job.DeletedAt = DateTime.UtcNow;
        if (job.JobSchedule != null)
        {
            job.JobSchedule.DeletedAt = DateTime.UtcNow;
        }
        
        
        await _context.SaveChangesAsync();
    }
    
    public override async Task RestoreAsync(int jobId)
    {
        var job = await GetJobWithScheduleByIdAsync(jobId);
        if (job == null || job.DeletedAt != null)
        {
            return;
        }

        job.DeletedAt = null;
        if (job.JobSchedule != null && job.JobSchedule.DeletedAt == null)
        {
            job.JobSchedule.DeletedAt = null;
        }
        
        
        await _context.SaveChangesAsync();
    }
}