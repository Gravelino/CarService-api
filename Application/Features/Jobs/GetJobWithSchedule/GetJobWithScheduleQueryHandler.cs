using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobWithSchedule;

public class GetJobWithScheduleQueryHandler : IRequestHandler<GetJobWithScheduleQuery, Job?>
{
    private readonly IJobRepository _repository;

    public GetJobWithScheduleQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<Job?> Handle(GetJobWithScheduleQuery request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetJobWithScheduleByIdAsync(request.JobId);
        if(job is null)
            throw new Exception("Job is not found");
        
        return job;
    }
}