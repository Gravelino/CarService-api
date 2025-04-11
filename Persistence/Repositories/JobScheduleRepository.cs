using Application.Interfaces;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class JobScheduleRepository : SoftDeletableRepository<JobSchedule>,  IJobScheduleRepository
{
    public JobScheduleRepository(CarServiceDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobSchedule>> GetAllJobSchedulesForWorker(int workerId)
    {
        var jobSchedules = await _context.JobSchedules
            .Where(schedule => schedule.WorkerId == workerId)
            .ToListAsync();
        
        return jobSchedules;
    }

    public async Task<IEnumerable<JobSchedule>> GetActiveJobSchedulesForWorker(int workerId)
    {
        var jobSchedules = await _context.JobSchedules
            .Where(schedule => schedule.WorkerId == workerId &&
                               schedule.StartDate < DateTime.UtcNow &&
                               schedule.EndDate > DateTime.UtcNow)
            .ToListAsync();
        
        return jobSchedules;
    }

    public async Task<IEnumerable<JobSchedule>> GetPlannedJobSchedulesForWorker(int workerId)
    {
        var jobSchedules = await _context.JobSchedules
            .Where(schedule => schedule.WorkerId == workerId &&
                               schedule.StartDate > DateTime.UtcNow)
            .ToListAsync();
        
        return jobSchedules;
    }
}