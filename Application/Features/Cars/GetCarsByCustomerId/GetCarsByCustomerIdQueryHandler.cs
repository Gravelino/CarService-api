using Application.Interfaces;
using Application.Models;
using MediatR;

namespace Application.Features.Cars.GetCarsByCustomerId;

public class GetCarsByCustomerIdQueryHandler : IRequestHandler<GetCarsByCustomerIdQuery, IEnumerable<Car>>
{
    private readonly ICarRepository _carRepository;

    public GetCarsByCustomerIdQueryHandler(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<Car>> Handle(GetCarsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var cars = await _carRepository.GetCarsByCustomerIdAsync(request.CustomerId);
        return cars.Where(c => c.DeletedAt == null).ToList();
    }
}