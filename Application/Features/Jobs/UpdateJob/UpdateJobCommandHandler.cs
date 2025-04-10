using Application.Interfaces;
using MediatR;

namespace Application.Features.Jobs.UpdateJob;

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
{
    private readonly IJobRepository _jobRepository;
    private readonly IWorkerRepository _workerRepository;

    public UpdateJobCommandHandler(IJobRepository jobRepository, IWorkerRepository workerRepository)
    {
        _jobRepository = jobRepository;
        _workerRepository = workerRepository;
    }

    public async Task Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetJobWithScheduleByIdAsync(request.JobId);
        if(job is null)
            throw new Exception("Job not found");

        
        if (request.Price.HasValue) job.Price = request.Price.Value;
        if (request.ServiceId.HasValue) job.ServiceId = request.ServiceId.Value;
        if (request.WorkerId.HasValue)
        {
            var isWorkerAvailable = await _workerRepository.IsWorkerAvailableByIdAsync(request.WorkerId.Value,
                job.JobSchedule.StartDate, job.JobSchedule.EndDate);
            if (!isWorkerAvailable)
            {
               throw new Exception("Worker not available");
            }
            job.WorkerId = request.WorkerId.Value;
        }
        
        await _jobRepository.Update(job);
        await _jobRepository.SaveChangesAsync();
    }
}