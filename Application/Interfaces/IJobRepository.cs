using Application.Models;

namespace Application.Interfaces;

public interface IJobRepository : ISoftDeletableRepository<Job>
{
    Task<Job?> GetJobWithScheduleByIdAsync(int jobId);
    Task<IEnumerable<Job>> GetJobsWithSchedulesByVisitIdAsync(int visitId);
    Task<IEnumerable<Job>> GetAllJobsWithSchedules();
}