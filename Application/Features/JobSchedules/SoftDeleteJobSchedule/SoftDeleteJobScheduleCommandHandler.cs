using Application.Interfaces;
using MediatR;

namespace Application.Features.JobSchedules.SoftDeleteJobSchedule;

public class SoftDeleteJobScheduleCommandHandler : IRequestHandler<SoftDeleteJobScheduleCommand>
{
    private readonly IJobScheduleRepository _repository;

    public SoftDeleteJobScheduleCommandHandler(IJobScheduleRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(SoftDeleteJobScheduleCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetByIdAsync(request.JobId);
        if(job == null)
            throw new Exception("Job not found");
        
        await _repository.SoftDeleteAsync(job.Id);
    }
}