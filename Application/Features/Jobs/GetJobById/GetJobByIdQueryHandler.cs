using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Jobs.GetJobById;

public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Job?>
{
    private readonly IJobRepository _repository;

    public GetJobByIdQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Job?> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetByIdAsync(request.JobId);
        
        return job;
    }
}