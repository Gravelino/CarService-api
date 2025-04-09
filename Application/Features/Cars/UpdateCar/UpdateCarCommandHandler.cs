using Application.Interfaces;
using MediatR;

namespace Application.Features.Cars.UpdateCar;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
{
    private readonly ICarRepository _carRepository;

    public UpdateCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carRepository.GetByIdAsync(request.Id);
        if (car == null)
        {
            throw new Exception("Car not found");
        }
        
        if (request.Brand is not null) car.Brand = request.Brand;
        if (request.Model is not null) car.Model = request.Model;
        if (request.LicensePlate is not null) car.LicensePlate = request.LicensePlate;
        if (request.Color is not null) car.Color = request.Color;
        if(request.Year.HasValue) car.Year = request.Year.Value;
        if(request.CustomerId.HasValue) car.CustomerId = request.CustomerId.Value;

        await _carRepository.Update(car);
        await _carRepository.SaveChangesAsync();
    }
}