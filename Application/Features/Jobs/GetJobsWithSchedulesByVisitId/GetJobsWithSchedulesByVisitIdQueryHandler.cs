using Application.Features.Jobs.GetJobWithSchedule;
using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobsWithSchedulesByVisitId;

public class GetJobsWithSchedulesByVisitIdQueryHandler : IRequestHandler<GetJobsWithSchedulesByVisitIdQuery, IEnumerable<Job>>
{
    private readonly IJobRepository _jobRepository;

    public GetJobsWithSchedulesByVisitIdQueryHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    public async Task<IEnumerable<Job>> Handle(GetJobsWithSchedulesByVisitIdQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _jobRepository.GetJobsWithSchedulesByVisitIdAsync(request.VisitId);
        return jobs;
    }
}