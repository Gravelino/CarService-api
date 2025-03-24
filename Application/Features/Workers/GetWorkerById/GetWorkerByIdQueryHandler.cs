using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Workers.GetWorkerById;

public class GetWorkerByIdQueryHandler : IRequestHandler<GetWorkerByIdQuery, Worker?>
{
    private readonly IWorkerRepository _repository;

    public GetWorkerByIdQueryHandler(IWorkerRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Worker?> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
    {
        var worker = await _repository.GetByIdAsync(request.WorkerId);
        return worker;
    }
}