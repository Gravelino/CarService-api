using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.GetCarWithVisitHistory;

public class GetCarWithVisitHistoryQueryHandler : IRequestHandler<GetCarWithVisitHistoryQuery, Car?>
{
    private readonly ICarRepository _carRepository;

    public GetCarWithVisitHistoryQueryHandler(ICarRepository carRepository)
    {
        this._carRepository = carRepository;
    }

    public async Task<Car?> Handle(GetCarWithVisitHistoryQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetCarWithVisitHistoryAsync(request.CarId);
        return car;
    }
}