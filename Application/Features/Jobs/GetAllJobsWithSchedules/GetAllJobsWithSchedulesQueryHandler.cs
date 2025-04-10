using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetAllJobsWithSchedules;

public class GetAllJobsWithSchedulesQueryHandler : IRequestHandler<GetAllJobsWithSchedulesQuery, IEnumerable<Job>>
{
    private readonly IJobRepository _repository;

    public GetAllJobsWithSchedulesQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Job>> Handle(GetAllJobsWithSchedulesQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _repository.GetAllJobsWithSchedules();
        return jobs;
    }
}