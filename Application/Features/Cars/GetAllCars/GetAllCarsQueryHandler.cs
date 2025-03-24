using Application.Models;
using MediatR;
using Persistence.Repositories.Interfaces;

namespace Application.Features.Cars.GetAllCars;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
{
    private readonly ICarRepository _repository;

    public GetAllCarsQueryHandler(ICarRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = await  _repository.GetAllAsync();
        return cars.Where(c => c.DeletedAt == null).ToList();
    }
}