using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.GetJobScheduleById;

public class GetJobScheduleByIdQueryHandler : IRequestHandler<GetJobScheduleByIdQuery, JobSchedule?>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;

    public GetJobScheduleByIdQueryHandler(IJobScheduleRepository jobScheduleRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
    }

    public async Task<JobSchedule?> Handle(GetJobScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var jobSchedule = await _jobScheduleRepository.GetByIdAsync(request.Id);
        return jobSchedule;
    }
}