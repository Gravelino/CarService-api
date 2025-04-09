using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetVisitById;

public class GetVisitByIdQuery : IRequest<Visit?>
{
    public int Id { get; set; }
}