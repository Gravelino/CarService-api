using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.SoftDeleteCar;

public class SoftDeleteCarCommandHandler : IRequestHandler<SoftDeleteCarCommand, bool>
{
    private readonly ICarRepository _carRepository;

    public SoftDeleteCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<bool> Handle(SoftDeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            return false;
        }
        
        await _carRepository.SoftDeleteAsync(car.Id);
        
        return true;
    }
}