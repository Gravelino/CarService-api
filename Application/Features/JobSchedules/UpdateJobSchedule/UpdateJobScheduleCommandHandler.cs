using Application.Interfaces;
using MediatR;

namespace Application.Features.JobSchedules.UpdateJobSchedule;

public class UpdateJobScheduleCommandHandler : IRequestHandler<UpdateJobScheduleCommand>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;
    private readonly IWorkerRepository _workerRepository;

    public UpdateJobScheduleCommandHandler(IJobScheduleRepository jobScheduleRepository, IWorkerRepository workerRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
        _workerRepository = workerRepository;
    }

    public async Task Handle(UpdateJobScheduleCommand request, CancellationToken cancellationToken)
    {
        var jobSchedule = await _jobScheduleRepository.GetByIdAsync(request.JobScheduleId);
        if(jobSchedule is null)
            throw new Exception("JobSchedule not found");

        
        if (request.JobId.HasValue) jobSchedule.JobId = request.JobId.Value;
        if (request.StartDate.HasValue) jobSchedule.StartDate = request.StartDate.Value;
        if (request.EndDate.HasValue) jobSchedule.EndDate = request.EndDate.Value;
        if (request.WorkerId.HasValue)
        {
            var isWorkerAvailable = await _workerRepository.IsWorkerAvailableByIdAsync(request.WorkerId.Value,
                jobSchedule.StartDate, jobSchedule.EndDate);
            if (!isWorkerAvailable)
            {
               throw new Exception("Worker not available");
            }
            jobSchedule.WorkerId = request.WorkerId.Value;
        }
        
        await _jobScheduleRepository.Update(jobSchedule);
        await _jobScheduleRepository.SaveChangesAsync();
    }
}