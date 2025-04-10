using Application.Interfaces;
using MediatR;

namespace Application.Features.Jobs.RestoreJob;

public class RestoreJobCommandHandler: IRequestHandler<RestoreJobCommand>
{
    private readonly IJobRepository _repository;

    public RestoreJobCommandHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RestoreJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetByIdAsync(request.JobId);
        if(job == null)
            throw new Exception("Job not found");
        
        await _repository.RestoreAsync(job.Id);
    }
}