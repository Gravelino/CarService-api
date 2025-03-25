using Application.Interfaces;
using MediatR;

namespace Application.Features.Workers.UpdateWorker;

public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand>
{
    private readonly IWorkerRepository _workerRepository;

    public UpdateWorkerCommandHandler(IWorkerRepository workerRepository)
    {
        _workerRepository = workerRepository;
    }
    
    public async Task Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = await _workerRepository.GetByIdAsync(request.Id);
        if (worker == null)
        {
            throw new Exception("Worker not found");
        }
        
        if(request.FirstName is not null) worker.FirstName = request.FirstName;
        if(request.LastName is not null) worker.LastName = request.LastName;
        if(request.Specialization is not null) worker.Specialization = request.Specialization;
        if(request.HireDate is not null) worker.HireDate = (DateTime)request.HireDate;
        if(request.Phone is not null) worker.Phone = request.Phone;
        if(request.Email is not null) worker.Email = request.Email;
        if(request.Salary is not null) worker.Salary = (decimal)request.Salary;
        if(request.IsActive is not null) worker.IsActive = (bool)request.IsActive;
        
        _workerRepository.Update(worker);
        await _workerRepository.SaveChangesAsync();
    }
}