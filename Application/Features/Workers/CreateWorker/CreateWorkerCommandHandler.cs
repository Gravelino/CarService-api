using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Workers.CreateWorker;

public class CreateWorkerCommandHandler : IRequestHandler<CreateWorkerCommand, int>
{
    private readonly IWorkerRepository _workerRepository;

    public CreateWorkerCommandHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }
    
    public async Task<int> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = new Worker
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Specialization = request.Specialization,
            Salary = request.Salary,
            Phone = request.Phone,
            HireDate = request.HireDate ?? DateTime.UtcNow,
            Email = request.Email,
            IsActive = request.IsActive,
        };
        
        await _workerRepository.AddAsync(worker);
        await _workerRepository.SaveChangesAsync();
        
        return worker.Id;
    }
}