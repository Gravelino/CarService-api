using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.RestoreCar;

public class RestoreCarCommandHandler : IRequestHandler<RestoreCarCommand, bool>
{
    private readonly ICarRepository _carRepository;

    public RestoreCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<bool> Handle(RestoreCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            return false;
        }
        
        await _carRepository.RestoreAsync(car.Id);
        
        return true;
    }
}