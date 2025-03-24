using Application.Models;
using MediatR;

namespace Application.Features.Cars.GetCarWithVisitHistory;

public class GetCarWithVisitHistoryQuery : IRequest<Car?>
{
    public int CarId { get; set; }
}