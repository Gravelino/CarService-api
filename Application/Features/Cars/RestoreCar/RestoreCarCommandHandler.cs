using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.RestoreCar;

public class RestoreCarCommandHandler : IRequestHandler<RestoreCarCommand>
{
    private readonly ICarRepository _carRepository;

    public RestoreCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task Handle(RestoreCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }
        
        await _carRepository.RestoreAsync(car.Id);
    }
}