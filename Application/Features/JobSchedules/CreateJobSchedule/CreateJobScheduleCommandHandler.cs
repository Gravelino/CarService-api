using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.JobSchedules.CreateJobSchedule;

public class CreateJobScheduleCommandHandler : IRequestHandler<CreateJobScheduleCommand, int>
{
    private readonly IJobScheduleRepository _jobScheduleRepository;

    public CreateJobScheduleCommandHandler(IJobScheduleRepository jobScheduleRepository)
    {
        _jobScheduleRepository = jobScheduleRepository;
    }

    public async Task<int> Handle(CreateJobScheduleCommand request, CancellationToken cancellationToken)
    {
        var jobSchedule = new JobSchedule
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            JobId = request.JobId,
            WorkerId = request.WorkerId,
        };
        
        await _jobScheduleRepository.AddAsync(jobSchedule);
        await _jobScheduleRepository.SaveChangesAsync();
        
        return jobSchedule.Id;
    }
}