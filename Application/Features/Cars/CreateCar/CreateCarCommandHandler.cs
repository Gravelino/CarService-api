using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.CreateCar;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, int>
{
    private readonly ICarRepository _carRepository;

    public CreateCarCommandHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    
    public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            Model = request.Model,
            Brand = request.Brand,
            Color = request.Color,
            Year = request.Year,
            LicensePlate = request.LicensePlate,
            CustomerId = request.CustomerId
        };

        await _carRepository.AddAsync(car);
        await _carRepository.SaveChangesAsync();
        
        return car.Id;
    }
}