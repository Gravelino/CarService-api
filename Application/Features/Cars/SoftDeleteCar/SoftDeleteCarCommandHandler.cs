using Application.Interfaces;
using MediatR;

namespace Application.Features.Cars.SoftDeleteCar;

public class SoftDeleteCarCommandHandler : IRequestHandler<SoftDeleteCarCommand>
{
    private readonly ICarRepository _carRepository;

    public SoftDeleteCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task Handle(SoftDeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }
        
        await _carRepository.SoftDeleteAsync(car.Id);
    }
}