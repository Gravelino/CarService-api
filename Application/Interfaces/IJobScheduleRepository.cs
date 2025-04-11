using Application.Models;

namespace Application.Interfaces;

public interface IJobScheduleRepository : ISoftDeletableRepository<JobSchedule>
{
    Task<IEnumerable<JobSchedule>> GetAllJobSchedulesForWorker(int workerId);
    Task<IEnumerable<JobSchedule>> GetActiveJobSchedulesForWorker(int workerId);
    Task<IEnumerable<JobSchedule>> GetPlannedJobSchedulesForWorker(int workerId);
}