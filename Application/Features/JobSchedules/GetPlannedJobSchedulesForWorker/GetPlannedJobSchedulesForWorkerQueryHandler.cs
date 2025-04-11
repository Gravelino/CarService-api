using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetPlannedJobSchedulesForWorker;

public class GetPlannedJobSchedulesForWorkerQueryHandler : IRequestHandler<GetPlannedJobSchedulesForWorkerQuery, IEnumerable<JobSchedule>>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;

    public GetPlannedJobSchedulesForWorkerQueryHandler(IJobScheduleRepository jobScheduleRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
    }

    public async Task<IEnumerable<JobSchedule>> Handle(GetPlannedJobSchedulesForWorkerQuery request, CancellationToken cancellationToken)
    {
        var jobSchedules = await _jobScheduleRepository.GetPlannedJobSchedulesForWorker(request.WorkerId);
        return jobSchedules;
    }
}