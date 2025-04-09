using Application.Models;
using MediatR;

namespace Application.Features.Workers.GetWorkerWithScheduledVisitsById;

public class GetWorkerWithScheduledVisitsByIdQuery : IRequest<Worker?>
{
    public int WorkerId { get; set; }
}