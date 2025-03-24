using Application.Models;
using MediatR;

namespace Application.Features.Visits.GetAllVisits;

public class GetAllVisitsQuery : IRequest<IEnumerable<Visit>>
{
    
}