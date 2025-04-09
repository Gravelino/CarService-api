using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitWithServicesAndWorkersById;

public class GetVisitWithServicesAndWorkersByIdQuery : IRequest<Visit?>
{
    public int VisitId { get; set; }
}
