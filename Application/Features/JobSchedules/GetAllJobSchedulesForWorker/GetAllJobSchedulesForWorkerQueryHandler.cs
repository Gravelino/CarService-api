using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetAllJobSchedulesForWorker;

public class GetAllJobSchedulesForWorkerQueryHandler : IRequestHandler<GetAllJobSchedulesForWorkerQuery, IEnumerable<JobSchedule>>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;

    public GetAllJobSchedulesForWorkerQueryHandler(IJobScheduleRepository jobScheduleRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
    }

    public async Task<IEnumerable<JobSchedule>> Handle(GetAllJobSchedulesForWorkerQuery request, CancellationToken cancellationToken)
    {
        var jobSchedules = await _jobScheduleRepository.GetAllJobSchedulesForWorker(request.WorkerId);
        return jobSchedules;
    }
}