using Application.Models;

namespace Application.Interfaces;

public interface IJobRepository : ISoftDeletableRepository<Job>
{
    Task<IEnumerable<Job>> GetJobsWithSchedulesByVisitIdAsync(int visitId);
    Task<IEnumerable<Job>> GetAllJobsWithSchedules();
}