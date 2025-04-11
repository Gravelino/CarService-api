using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetActiveJobSchedulesForWorker;

public class GetActiveJobSchedulesForWorkerQueryHandler : IRequestHandler<GetActiveJobSchedulesForWorkerQuery, IEnumerable<JobSchedule>>
{
    private readonly IJobScheduleRepository _repository;

    public GetActiveJobSchedulesForWorkerQueryHandler(IJobScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<JobSchedule>> Handle(GetActiveJobSchedulesForWorkerQuery request, CancellationToken cancellationToken)
    {
        var jobSchedules = await _repository.GetActiveJobSchedulesForWorker(request.WorkerId);
        return jobSchedules;
    }
}