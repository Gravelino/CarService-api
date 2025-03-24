using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetAllWorkers;

public class GetAllWorkersQuery : IRequest<IEnumerable<Worker>>
{
    
}