using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.GetCarById;

public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, Car?>
{
    private readonly ICarRepository _carRepository;

    public GetCarByIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.CarId);
        return car;
    }
}