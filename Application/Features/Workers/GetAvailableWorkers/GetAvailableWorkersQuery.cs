using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetAvailableWorkers;

public class GetAvailableWorkersQuery : IRequest<IEnumerable<Worker>>
{
    
}