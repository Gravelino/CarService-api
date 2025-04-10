using Application.Interfaces;
using MediatR;

namespace Application.Features.Jobs.SoftDeleteJob;

public class SoftDeleteJobCommandHandler : IRequestHandler<SoftDeleteJobCommand>
{
    private readonly IJobRepository _repository;

    public SoftDeleteJobCommandHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(SoftDeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetByIdAsync(request.JobId);
        if(job == null)
            throw new Exception("Job not found");
        
        await _repository.SoftDeleteAsync(job.Id);
    }
}