using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.UpdateCar;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, bool>
{
    private readonly ICarRepository _carRepository;

    public UpdateCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            return false;
        }
        
        if (request.Brand is not null) car.Brand = request.Brand;
        if (request.Model is not null) car.Model = request.Model;
        if (request.LicensePlate is not null) car.LicensePlate = request.LicensePlate;
        if (request.Color is not null) car.Color = request.Color;
        if(request.Year is not null) car.Year = (int)request.Year;
        if(request.CustomerId is not null) car.CustomerId = (int)request.CustomerId;

        _carRepository.Update(car);
        await _carRepository.SaveChangesAsync();
        
        return true;
    }
}