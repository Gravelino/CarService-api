using Application.Interfaces;
using MediatR;

namespace Application.Features.JobSchedules.RestoreJobSchedule;

public class RestoreJobScheduleCommandHandler: IRequestHandler<RestoreJobScheduleCommand>
{
    private readonly IJobScheduleRepository _repository;

    public RestoreJobScheduleCommandHandler(IJobScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RestoreJobScheduleCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetByIdAsync(request.JobId);
        if(job == null)
            throw new Exception("JobSchedule not found");
        
        await _repository.RestoreAsync(job.Id);
    }
}