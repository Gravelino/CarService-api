using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Jobs.CreateJob;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
{
    private readonly IJobRepository _jobRepository;

    public CreateJobCommandHandler(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }
    
    public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = new Job
        {
            Price = request.Price,
            ServiceId = request.ServiceId,
            VisitId = request.VisitId,
            WorkerId = request.WorkerId,
        };

        await _jobRepository.AddAsync(job);
        await _jobRepository.SaveChangesAsync();
        
        return job.Id;
    }
}